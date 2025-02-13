using Kup1Gis.Domain.Entity.KupEntity.ObservationEntity;

namespace Kup1Gis.Domain.Entity.KupEntity;

public class Observation
{
    public long Id { get; set; }
    public long KupId { get; set; }
    public virtual Kup Kup { get; set; } = null!;
    public virtual List<KupProperty> KupProperties { get; set; } = [];
}