using Kup1Gis.Domain.Entity;
using Kup1Gis.Domain.RepoInterfaces;
using Kup1Gis.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kup1Gis.Infrastructure.Repositories.Implications;

public sealed class KupRepository : Repository, IKupRepository
{
    public KupRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddAsync(Kup entity, CancellationToken token = default)
    {
        await Context.Kups.AddAsync(entity, token);
        await Context.SaveChangesAsync(token);
    }

    public async Task<Kup> FindAsync(long id, CancellationToken token = default)
    {
        var result = await Context.Kups.FindAsync([id], token);
        if (result == null)
            //Todo: обработать ошибку
            throw new KeyNotFoundException();

        return result;
    }

    public async Task UpdateAsync(Kup entity, CancellationToken token = default)
    {
        Context.Kups.Update(entity);
        await Context.SaveChangesAsync(token);
    }

    public async Task<IReadOnlyList<Kup>> GetAllAsync(CancellationToken token = default)
    {
        return await Context.Kups
            .Select(k => k)
            .ToListAsync(token);
    }

    public Task DeleteAsync(Kup entity, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Kup> FindByNameAsync(string name, CancellationToken token = default)
    {
        var result = await Context.Kups
            .Include(k => k.Properties)
            .ThenInclude(kp => kp.Property)
            .Where(k => k.Name == name)
            .FirstOrDefaultAsync(token);

        if (result == null)
            //Todo: обработать ошибку
            throw new KeyNotFoundException();

        return result;
    }

    public async Task<Kup> FindByIdAsync(long id, CancellationToken token = default)
    {
        var result = await Context.Kups
            .Where(k => k.Id == id)
            .FirstOrDefaultAsync(token);

        if (result == null)
            //Todo: обработать ошибку
            throw new KeyNotFoundException();

        return result;
    }

    public async Task<bool> ContainsNameAsync(string name, CancellationToken token = default)
    {
        return await Context.Kups
            .Where(k => k.Name == name)
            .AnyAsync(token);
    }

    public async Task<bool> ContainsIdAsync(long id, CancellationToken token = default)
    {
        return await Context.Kups
            .Where(k => k.Id == id)
            .AnyAsync(token);
    }

    public async Task<long[]> GetAllIdsAsync(CancellationToken token = default)
    {
        return await Context.Kups
            .Select(k => k.Id)
            .ToArrayAsync(token);
    }
}