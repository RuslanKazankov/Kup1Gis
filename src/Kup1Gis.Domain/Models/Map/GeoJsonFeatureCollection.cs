namespace Kup1Gis.Domain.Models.Map;

public class GeoJsonFeatureCollection
{
    public string Type { get; set; } = "FeatureCollection";

    public List<GeoJsonFeature> Features { get; set; }
}