using System.Text.Json;
using Kup1Gis.Domain.Models;
using Kup1Gis.Domain.Models.Kup;
using Kup1Gis.Domain.Services;
using Kup1Gis.Domain.Services.Implications;
using Microsoft.AspNetCore.Mvc;

namespace Kup1Gis.Controllers;

public class KupController : Controller
{
    private readonly ILogger<KupController> _logger;
    private readonly IKupService _kupService;
    private readonly IExcelService _excelService;

    public KupController(
        ILogger<KupController> logger, 
        IKupService kupService,
        IExcelService excelService)
    {
        _logger = logger;
        _kupService = kupService;
        _excelService = excelService;
    }
        
    [HttpPost]
    public async Task<IActionResult> Add(ObservationModel model)
    {
        _logger.LogInformation("Add request: {KupModel}", JsonSerializer.Serialize<ObservationModel>(model));
        
        long id = await _kupService.AddKup(model);
        var kups = _kupService.GetObservations(id);
        string jsonResult = JsonSerializer.Serialize(kups);
        
        _logger.LogInformation("Add response: {result}", JsonSerializer.Serialize(jsonResult));
        return Ok(jsonResult);
    }

    [HttpPost]
    public async Task<IActionResult> ImportExcel(IFormFile excelFile)
    {
        ExcelType? excelType = null;
        string extension = Path.GetExtension(excelFile.FileName).ToLower();
        if (string.Equals(extension, ExcelService.HssFormat))
        {
            excelType = ExcelType.Xls;
        }
        if (string.Equals(extension, ExcelService.XssFormat))
        {
            excelType = ExcelType.Xlsx;
        }
        if (excelType is null)
        {
            return BadRequest("Need excel format (.xls or .xlsx)");
        }
        var kupModels = await _excelService.ReadKupModels(excelFile.OpenReadStream(), excelType.Value);
        List<string> exceptions = [];
        foreach (var kupModel in kupModels)
        {
            try
            {
                await _kupService.AddKup(kupModel);
            }
            catch (Exception e)
            {
                string message = $"Id: {kupModel.Id}, Name: {kupModel.Name}{Environment.NewLine}{e.Message}";
                exceptions.Add(message);
                _logger.LogWarning(message);
            }
        }
        return Ok("Success import");
    }
}