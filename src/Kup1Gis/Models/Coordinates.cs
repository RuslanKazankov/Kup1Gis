namespace Kup1Gis.Models;

public record Coordinates
{
    public required decimal Latitude { get; init; }
    public required decimal Longitude { get; init; }
    public double? AbsMarkOfSea { get; init; } = null;
    public string Eksp { get; init; } = string.Empty;
}