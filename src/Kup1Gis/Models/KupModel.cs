namespace Kup1Gis.Models;

public record KupModel
{
    public long? Id { get; init; }
    public required string Name { get; init; }
    public string GeographicalReference { get; init; } = string.Empty;
    public required CoordinatesModel CoordinatesModel { get; init; }
}