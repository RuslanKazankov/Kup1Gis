namespace Kup1Gis.Domain.Entity;

public class Coordinates
{
    public long Id { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public double? AbsMarkOfSea { get; set; }
    public string Eksp { get; set; } = string.Empty;
    public long KupId { get; set; }
    public virtual Kup Kup { get; set; } = null!;
}