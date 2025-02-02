using Kup1Gis.Domain.Entity;
using Kup1Gis.Domain.Models.Kup;

namespace Kup1Gis.Domain.Services;

public interface IKupService
{
    Task<long> AddKup(KupModel model, CancellationToken token = default);
    Task<IReadOnlyList<KupModel>> GetKups(long id, CancellationToken token = default);
}