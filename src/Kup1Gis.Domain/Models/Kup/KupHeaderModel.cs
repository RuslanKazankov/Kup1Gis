using Kup1Gis.Domain.Entity.KupEntity;

namespace Kup1Gis.Domain.Models.Kup;

public sealed record KupHeaderModel
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string GeographicalReference { get; set; } = string.Empty;
    public CoordinatesModel Coordinates { get; set; } = null!;
}