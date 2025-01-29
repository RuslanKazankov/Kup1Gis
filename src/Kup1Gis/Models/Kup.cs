namespace Kup1Gis.Models;

public record Kup
{
    public long? Id { get; init; }
    public required long Name { get; init; }
    public string GeographicalReference { get; init; } = string.Empty;
    public required Coordinates Coordinates { get; init; }
}