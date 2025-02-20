namespace Kup1Gis.Domain.Models.Kup;

public sealed record ObservationModel
{
    public required string Name { get; init; }
    public IReadOnlyList<PropertyModel> Properties { get; init; } = [];
}