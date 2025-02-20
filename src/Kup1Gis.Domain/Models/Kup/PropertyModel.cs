namespace Kup1Gis.Domain.Models.Kup;

public sealed record PropertyModel
{
    public required string Name { get; init; }
    public required string Value { get; init; }
}