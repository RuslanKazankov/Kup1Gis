using Kup1Gis.Domain.Models;
using Kup1Gis.Domain.Models.Kup;

namespace Kup1Gis.Domain.Services;

public interface IExcelService
{
    Task<IReadOnlyList<KupModel>> ReadKupModels(Stream fileStream, ExcelType type, CancellationToken token = default);
}