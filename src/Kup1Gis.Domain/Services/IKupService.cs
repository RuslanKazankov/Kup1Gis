using Kup1Gis.Domain.Models.Kup;

namespace Kup1Gis.Domain.Services;

public interface IKupService
{
    Task<long> AddKup(KupHeadModel model, CancellationToken token = default);
    Task<FullKupModel> GetFullKup(long id, CancellationToken token = default);
    Task<long> AddObservation(ObservationModel model, CancellationToken token = default);
    Task<IReadOnlyList<ObservationModel>> GetObservations(long kupId, CancellationToken token = default);
    Task<IReadOnlyList<KupHeadModel>> GetAllKups(CancellationToken token = default);
}