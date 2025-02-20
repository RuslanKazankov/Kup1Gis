namespace Kup1Gis.Domain.Models.Kup;

public sealed record KupHeadModel
{
    public required long Id { get; init; }
    public required string Name { get; init; }
    public string? GeographicalReference { get; init; } = null;
    public required CoordinatesModel Coordinates { get; init; }
}