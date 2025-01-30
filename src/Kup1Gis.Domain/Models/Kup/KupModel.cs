using System.Collections.ObjectModel;
using Kup1Gis.Models.Kup;

namespace Kup1Gis.Models;

public record KupModel
{
    public long? Id { get; init; } = null;
    public required string Name { get; init; }
    public string GeographicalReference { get; init; } = string.Empty;
    public required CoordinatesModel Coordinates { get; init; }
    public ReadOnlyCollection<PropertyModel> KupProperties { get; init; } = [];
}