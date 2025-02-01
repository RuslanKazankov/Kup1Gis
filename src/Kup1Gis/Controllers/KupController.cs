using System.Text.Json;
using Kup1Gis.Domain.Models.Kup;
using Microsoft.AspNetCore.Mvc;

namespace Kup1Gis.Controllers;

public class KupController : Controller
{
    private readonly ILogger<KupController> _logger;

    public KupController(ILogger<KupController> logger)
    {
        _logger = logger;
    }
        
    [HttpPost]
    public async Task<IActionResult> Add(KupModel model)
    {
        _logger.LogInformation($"Add request: {JsonSerializer.Serialize<KupModel>(model)}");
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}