using Kup1Gis.Domain.Entity;
using Kup1Gis.Domain.Entity.KupEntity.ObservationEntity.KupPropertyEntity;

namespace Kup1Gis.Domain.RepoInterfaces;

public interface IPropertyRepository : IRepository<Property>
{
    Task<Property> FindByNameAsync(string name, CancellationToken token = default);
}