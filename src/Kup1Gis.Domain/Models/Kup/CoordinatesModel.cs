namespace Kup1Gis.Models;

public record CoordinatesModel
{
    public decimal Latitude { get; init; }
    public decimal Longitude { get; init; }
    public double? AbsMarkOfSea { get; init; } = null;
    public string Eksp { get; init; } = string.Empty;
}