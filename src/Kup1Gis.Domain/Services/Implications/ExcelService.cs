using Kup1Gis.Domain.Entity.KupEntity.ObservationEntity.KupPropertyEntity;
using Kup1Gis.Domain.Extensions;
using Kup1Gis.Domain.Models;
using Kup1Gis.Domain.Models.Kup;
using Kup1Gis.Domain.RepoInterfaces;
using Microsoft.Extensions.Logging;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Kup1Gis.Domain.Services.Implications;

public class ExcelService : IExcelService
{
    public const string XssFormat = ".xlsx";
    public const string HssFormat = ".xls";
    private readonly IKupService _kupService;

    private readonly ILogger<ExcelService> _logger;
    private readonly IPropertyRepository _propertyRepository;

    public ExcelService(
        ILogger<ExcelService> logger,
        IPropertyRepository propertyRepository,
        IKupService kupService)
    {
        _logger = logger;
        _propertyRepository = propertyRepository;
        _kupService = kupService;
    }

    public async Task<IReadOnlyList<string>> ReadKupModels(Stream fileStream, ExcelType type,
        CancellationToken token = default)
    {
        List<string> errors = [];

        IWorkbook? workbook = null;
        if (type == ExcelType.Xls) workbook = new HSSFWorkbook(fileStream);
        if (type == ExcelType.Xlsx) workbook = new XSSFWorkbook(fileStream);
        if (workbook is null) throw new ArgumentException("Excel file format not supported. Use .xls or .xlsx.");

        var index = 4;
        var sheet = workbook.GetSheetAt(0);
        var currentRow = sheet.GetRow(index);
        IReadOnlyList<Property> baseProperties = await _propertyRepository.GetAllAsync(token);
        while (!string.IsNullOrEmpty(currentRow.Cells[1].GetString()))
        {
            var id = currentRow.GetCell(0).GetLong();
            try
            {
                if (id is not null) await _kupService.AddKup(CreateKupHeadModel(id.Value, currentRow), token);

                await _kupService.AddObservation(CreateObservation(currentRow, baseProperties), token);
            }
            catch (Exception e)
            {
                _logger.LogWarning("{Title}{NewLine}{Message}",
                    "Failed to add kup or observation.",
                    Environment.NewLine,
                    e.Message);
                errors.Add(e.Message);
            }

            index++;
            currentRow = sheet.GetRow(index);
        }

        return errors;
    }

    private KupHeadModel CreateKupHeadModel(long id, IRow row)
    {
        return new KupHeadModel
        {
            Id = id,
            Name = row.GetCell(1).GetString(),
            GeographicalReference = row.GetCell(2).GetString(),
            Coordinates = new CoordinatesModel
            {
                Latitude = row.GetCell(3).GetDecimal() ??
                           throw new ArgumentNullException(
                               $"Проверьте координаты точки {row.Cells[0].GetLong()}"),
                Longitude = row.GetCell(4).GetDecimal() ??
                            throw new ArgumentNullException(
                                $"Проверьте координаты точки {row.Cells[0].GetLong()}"),
                AbsMarkOfSea = row.GetCell(5).GetDouble(),
                Eksp = row.GetCell(6).GetString()
            }
        };
    }

    private ObservationModel CreateObservation(IRow row, IReadOnlyList<Property> baseProperties)
    {
        List<PropertyModel> properties = [];
        for (var i = 0; i < baseProperties.Count; i++)
            properties.Add(new PropertyModel
            {
                Name = baseProperties[i].Name,
                Value = row.GetCell(i + 7).GetString()
            });

        return new ObservationModel
        {
            Name = row.GetCell(1).GetString(),
            Properties = properties
        };
    }
}