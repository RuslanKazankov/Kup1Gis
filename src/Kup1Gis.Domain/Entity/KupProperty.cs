namespace Kup1Gis.Domain.Entity;

public class KupProperty
{
    public long Id { get; set; }
    public long KupId { get; set; }
    public virtual Kup Kup { get; set; } = null!;
    public long PropertyId { get; set; }
    public virtual Property Property { get; set; } = null!;
    public string Value { get; set; } = string.Empty;
}