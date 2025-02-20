using Kup1Gis.Domain.Models;

namespace Kup1Gis.Domain.Services;

public interface IExcelService
{
    Task<IReadOnlyList<string>> ReadKupModels(Stream fileStream, ExcelType type, CancellationToken token = default);
}