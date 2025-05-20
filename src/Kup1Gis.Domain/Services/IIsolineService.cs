using Kup1Gis.Domain.Models.Map;

namespace Kup1Gis.Domain.Services;

public interface IIsolineService
{
    GeoJsonFeatureCollection GenerateIsolines(List<GeoPoint> points, int gridSize = 20);
}