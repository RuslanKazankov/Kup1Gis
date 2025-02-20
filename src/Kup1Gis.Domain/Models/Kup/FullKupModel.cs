using Kup1Gis.Domain.Models.FileModels;

namespace Kup1Gis.Domain.Models.Kup;

public sealed record FullKupModel
{
    public required long Id { get; init; }
    public required string Name { get; init; }

    public string? GeographicalReference { get; init; } = null;

    public required CoordinatesModel Coordinates { get; init; }
    public IReadOnlyList<ObservationModel> Observations { get; init; } = [];
    public IReadOnlyList<GetImageModel> KupImages { get; init; } = [];
}