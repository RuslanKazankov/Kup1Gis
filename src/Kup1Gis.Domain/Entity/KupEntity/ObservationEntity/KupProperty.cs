using Kup1Gis.Domain.Entity.KupEntity.ObservationEntity.KupPropertyEntity;

namespace Kup1Gis.Domain.Entity.KupEntity.ObservationEntity;

public class KupProperty
{
    public long Id { get; set; }
    public long PropertyId { get; set; }
    public virtual Property Property { get; set; } = null!;
    public virtual List<PropertyValue> Values { get; set; } = [];
}