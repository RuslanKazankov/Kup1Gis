using Kup1Gis.Domain.Entity;
using Kup1Gis.Domain.Entity.KupEntity;

namespace Kup1Gis.Domain.RepoInterfaces;

public interface IKupRepository : IRepository<Kup>
{
    Task<Kup> FindByNameAsync(string name, CancellationToken token = default);
    Task<Kup> FindByIdAsync(long id, CancellationToken token = default);
    Task<bool> ContainsNameAsync(string name, CancellationToken token = default);
    Task<bool> ContainsIdAsync(long id, CancellationToken token = default);
}