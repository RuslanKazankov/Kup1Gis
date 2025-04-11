namespace Kup1Gis.Domain.Entity.KupEntity.ObservationEntity.KupPropertyEntity;

public class PropertyValue
{
    public long Id { get; set; }
    public virtual KupProperty KupProperty { get; set; } = null!;
    public long KupPropertyId { get; set; }
    public string Value {get; set;} = string.Empty;
}