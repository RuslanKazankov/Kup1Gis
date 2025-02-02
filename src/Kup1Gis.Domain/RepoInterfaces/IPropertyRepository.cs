using Kup1Gis.Domain.Entity;

namespace Kup1Gis.Domain.RepoInterfaces;

public interface IPropertyRepository : IRepository<Property>
{
    Task<Property> FindByNameAsync(string name, CancellationToken token = default);
}