using System.Text.Json;
using Kup1Gis.Domain.Models.Kup;
using Kup1Gis.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kup1Gis.Controllers;

public class KupController : Controller
{
    private readonly ILogger<KupController> _logger;
    private readonly IKupService _kupService;

    public KupController(ILogger<KupController> logger, IKupService kupService)
    {
        _logger = logger;
        _kupService = kupService;
    }
        
    [HttpPost]
    public async Task<IActionResult> Add(KupModel model)
    {
        _logger.LogInformation("Add request: {KupModel}", JsonSerializer.Serialize<KupModel>(model));
        
        long id = await _kupService.AddKup(model);
        var kups = _kupService.GetKups(id);
        string jsonResult = JsonSerializer.Serialize(kups);
        
        _logger.LogInformation("Add response: {result}", JsonSerializer.Serialize(jsonResult));
        return Ok(jsonResult);
    }
}