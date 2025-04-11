using System.ComponentModel.DataAnnotations.Schema;
using Kup1Gis.Domain.Entity.KupEntity;
using Kup1Gis.Domain.Entity.KupEntity.ObservationEntity;

namespace Kup1Gis.Domain.Entity;

public class Kup
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string GeographicalReference { get; set; } = string.Empty;
    public virtual List<KupImage> KupImages { get; set; } = [];
    public long CoordinatesId { get; set; }
    public virtual Coordinates Coordinates { get; set; } = null!;
    public virtual List<KupProperty> Properties { get; set; } = [];

    //public virtual List<Observation> Observations { get; set; } = [];
}