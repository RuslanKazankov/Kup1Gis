using System.Diagnostics;
using Kup1Gis.Domain.Models;
using Kup1Gis.Domain.Services;
using Kup1Gis.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Kup1Gis.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPropertyService _propertyService;
    private readonly IKupService _kupService;

    public HomeController(
        ILogger<HomeController> logger, 
        IPropertyService propertyService,
        IKupService kupService)
    {
        _logger = logger;
        _propertyService = propertyService;
        _kupService = kupService;
    }

    public async Task<IActionResult> Index()
    {
        IndexViewModel model = new IndexViewModel()
        {
            Properties = await _propertyService.GetAllProperties(),
            AllKups = await _kupService.GetAllKups()
        };
        
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}