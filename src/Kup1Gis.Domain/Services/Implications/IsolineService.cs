using Kup1Gis.Domain.Common;
using Kup1Gis.Domain.Models.Map;

namespace Kup1Gis.Domain.Services.Implications;

public class IsolineService : IIsolineService
{
    public GeoJsonFeatureCollection GenerateIsolines(List<GeoPoint> points, int gridSize = 20)
    {
        double minLat = points.Min(p => p.Lat);
        double maxLat = points.Max(p => p.Lat);
        double minLon = points.Min(p => p.Lon);
        double maxLon = points.Max(p => p.Lon);

        double stepLat = (maxLat - minLat) / gridSize;
        double stepLon = (maxLon - minLon) / gridSize;

        var features = new List<GeoJsonFeature>();

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                double lat = minLat + i * stepLat;
                double lon = minLon + j * stepLon;
                double z = KrigingHelper.Predict(points, lon, lat);

                features.Add(new GeoJsonFeature()
                {
                    Type = "Feature",
                    Properties = { { "value", z } },
                    Geometry = new Geometry()
                    {
                        Type = "Point",
                        Coordinates = [lon, lat]
                    }
                });
            }
        }

        return new()
        {
            Type = "FeatureCollection",
            Features = features
        };
    }
}