using System.ComponentModel.DataAnnotations.Schema;

namespace Kup1Gis.Domain.Entity;

public class Kup
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string GeographicalReference { get; set; } = string.Empty;
    public long CoordinatesId { get; set; }
    public virtual Coordinates Coordinates { get; set; } = null!;
    public virtual List<Observation> Observations { get; set; } = [];
}