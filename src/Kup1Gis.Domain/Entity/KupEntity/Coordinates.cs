namespace Kup1Gis.Domain.Entity.KupEntity;

public class Coordinates
{
    public long Id { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public double? AbsMarkOfSea { get; set; }
    public string Eksp { get; set; } = string.Empty;
    public virtual Kup Kup { get; set; } = null!;
}