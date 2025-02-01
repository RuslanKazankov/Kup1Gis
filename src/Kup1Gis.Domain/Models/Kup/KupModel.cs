namespace Kup1Gis.Domain.Models.Kup;

public record KupModel
{
    public long? Id { get; init; } = null;
    public required string Name { get; init; }
    public string GeographicalReference { get; init; } = string.Empty;
    public required CoordinatesModel Coordinates { get; init; }
    public IReadOnlyList<PropertyModel> KupProperties { get; init; } = [];
}