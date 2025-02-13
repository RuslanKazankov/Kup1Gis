namespace Kup1Gis.Domain.Entity.KupEntity;

public class KupImage
{
    public long Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public long KupId { get; set; }
    public virtual Kup Kup { get; set; } = null!;
}