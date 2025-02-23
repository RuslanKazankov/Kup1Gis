namespace Kup1Gis.Domain.RepoInterfaces;

public interface IRepository<T> where T : class
{
    Task AddAsync(T entity, CancellationToken token = default);
    Task<T> FindAsync(long id, CancellationToken token = default);
    Task UpdateAsync(T entity, CancellationToken token = default);
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken token = default);
    Task DeleteAsync(T entity, CancellationToken token = default);
}