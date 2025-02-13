namespace Kup1Gis.Domain.Entity.KupEntity.ObservationEntity.KupPropertyEntity;

public class Property
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual List<KupProperty> KupProperties { get; set; } = [];
}