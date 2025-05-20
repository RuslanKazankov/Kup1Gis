namespace Kup1Gis.Domain.Models.Map;

public class GeoJsonFeature
{
    public string Type { get; set; } = "Feature";

    public Geometry Geometry { get; set; }

    public Dictionary<string, double> Properties { get; set; } = new();
}