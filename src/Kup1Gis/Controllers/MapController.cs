using Kup1Gis.Domain.Models.Kup;
using Kup1Gis.Domain.Models.Map;
using Kup1Gis.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kup1Gis.Controllers;

public class MapController : Controller
{
    private readonly IKupService _kupService;
    private readonly IIsolineService _isolineService;

    public MapController(IKupService kupService,
        IIsolineService isolineService)
    {
        _kupService = kupService;
        _isolineService = isolineService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetIsolinies()
    {
        List<FullKupModel> targetKups = (await _kupService.GetAllFullKups())
            .Where(k => k.KupProperties
                .Any(kp => kp.Name == "Vg, м3" && kp.Value.Count > 0))
            .ToList();
        
        List<GeoPoint> points = targetKups
            .Select(k => new GeoPoint()
            {
                Lat = (double)k.Coordinates.Latitude,
                Lon = (double)k.Coordinates.Longitude,
                Value = double.Parse(k.KupProperties.First(kp => kp.Name == "Vg, м3").Value.First())
            }).ToList();

        var geojson = _isolineService.GenerateIsolines(points);
        return Ok(geojson);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetNIsolinies()
    {
        List<FullKupModel> targetKups = (await _kupService.GetAllFullKups())
            .Where(k => k.KupProperties
                .Any(kp => kp.Name == "N, м2" && kp.Value.Count > 0))
            .ToList();
        
        List<GeoPoint> points = targetKups
            .Select(k => new GeoPoint()
            {
                Lat = (double)k.Coordinates.Latitude,
                Lon = (double)k.Coordinates.Longitude,
                Value = double.Parse(k.KupProperties.First(kp => kp.Name == "N, м2").Value.First())
            }).ToList();

        var geojson = _isolineService.GenerateIsolines(points);
        return Ok(geojson);
    }
}