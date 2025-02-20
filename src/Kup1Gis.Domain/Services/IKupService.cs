using Kup1Gis.Domain.Entity;
using Kup1Gis.Domain.Models.Kup;

namespace Kup1Gis.Domain.Services;

public interface IKupService
{
    Task<long> AddKup(ObservationModel model, CancellationToken token = default);
    Task<IReadOnlyList<ObservationModel>> GetObservations(long id, CancellationToken token = default);
    Task<IReadOnlyList<KupHeaderModel>> GetAllKups(CancellationToken token = default);
}