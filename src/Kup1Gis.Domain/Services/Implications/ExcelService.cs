using Kup1Gis.Domain.Entity;
using Kup1Gis.Domain.Extensions;
using Kup1Gis.Domain.Models;
using Kup1Gis.Domain.Models.Kup;
using Kup1Gis.Domain.RepoInterfaces;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Kup1Gis.Domain.Services.Implications;

public class ExcelService : IExcelService
{
    public const string XssFormat = ".xlsx";
    public const string HssFormat = ".xls";
    
    private readonly IPropertyRepository _propertyRepository;
    
    public ExcelService(IPropertyRepository propertyRepository)
    {
        _propertyRepository = propertyRepository;
    }
    
    public async Task<IReadOnlyList<KupModel>> ReadKupModels(Stream fileStream, ExcelType type, CancellationToken token = default)
    {
        IWorkbook? workbook = null;
        if (type == ExcelType.Xls)
        {
            workbook = new HSSFWorkbook(fileStream);
        }
        if (type == ExcelType.Xlsx)
        {
            workbook = new XSSFWorkbook(fileStream);
        }
        if (workbook is null)
        {
            throw new ArgumentException("Excel file format not supported. Use .xls or .xlsx.");
        }
        
        int index = 4;
        ISheet sheet = workbook.GetSheetAt(index: 0);
        IRow currentRow = sheet.GetRow(index);
        List<KupModel> kups = [];
        while (!string.IsNullOrEmpty(currentRow.Cells[1].GetString()))
        {
            List<PropertyModel> properties = [];
            IReadOnlyList<Property> baseProperties = await _propertyRepository.GetAllAsync(token);
            for (var i = 0; i < baseProperties.Count; i++)
            {
                properties.Add(new PropertyModel
                {
                    Name = baseProperties[i].Name,
                    Value = currentRow.Cells.Count <= i + 7 ? string.Empty : currentRow.Cells[i + 7].GetString()
                });
            }

            KupModel kup = new KupModel
            {
                Id = currentRow.Cells[0].GetLong(),
                Name = currentRow.Cells[1].GetString(),
                GeographicalReference = currentRow.Cells[2].GetString(),
                Coordinates = new CoordinatesModel
                {
                    Latitude = currentRow.Cells[3].GetDecimal() ?? throw new ArgumentNullException($"Проверьте координаты точки {currentRow.Cells[0].GetLong()}"),
                    Longitude = currentRow.Cells[4].GetDecimal() ?? throw new ArgumentNullException($"Проверьте координаты точки {currentRow.Cells[0].GetLong()}"),
                    AbsMarkOfSea = currentRow.Cells[5].GetDouble(),
                    Eksp = currentRow.Cells[6].GetString(),
                },
                Properties = properties
            };
            
            kups.Add(kup);
            index++;
            currentRow = sheet.GetRow(index);
        }
        return kups;
    }
}