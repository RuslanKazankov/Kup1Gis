using System.Text.Json;
using Kup1Gis.Domain.Models;
using Kup1Gis.Domain.Models.Kup;
using Kup1Gis.Domain.Services;
using Kup1Gis.Domain.Services.Implications;
using Microsoft.AspNetCore.Mvc;

namespace Kup1Gis.Controllers;

public class KupController : Controller
{
    private readonly IExcelService _excelService;
    private readonly IKupService _kupService;
    private readonly ILogger<KupController> _logger;

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
    public async Task<IActionResult> AddKup(KupHeadModel model)
    {
        _logger.LogInformation("Adding kup: {model}", Request);
        var id = await _kupService.AddKup(model);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetKup(long id)
    {
        var fullKup = await _kupService.GetFullKup(id);
        return Ok(fullKup);
    }

    [HttpPost]
    public async Task<IActionResult> ImportExcel(IFormFile excelFile)
    {
        ExcelType? excelType = null;
        var extension = Path.GetExtension(excelFile.FileName).ToLower();
        if (string.Equals(extension, ExcelService.HssFormat)) excelType = ExcelType.Xls;
        if (string.Equals(extension, ExcelService.XssFormat)) excelType = ExcelType.Xlsx;
        if (excelType is null) return BadRequest("Need excel format (.xls or .xlsx)");
        var errors = await _excelService.ReadKupModels(excelFile.OpenReadStream(), excelType.Value);
        return Ok(errors);
    }
}