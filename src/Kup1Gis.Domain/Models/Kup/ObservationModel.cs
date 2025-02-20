namespace Kup1Gis.Domain.Models.Kup;

public sealed record ObservationModel
{
    public long? Id { get; init; } = null;
    public required string Name { get; init; }
    
    private readonly string _geographicalReference = string.Empty;
    public string GeographicalReference
    {
        get => _geographicalReference;
        init => _geographicalReference = value ?? string.Empty;
    }

    public required CoordinatesModel Coordinates { get; init; }
    public IReadOnlyList<PropertyModel> Properties { get; init; } = [];
}