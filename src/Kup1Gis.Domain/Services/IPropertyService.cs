using Kup1Gis.Domain.Models.Kup;

namespace Kup1Gis.Domain.Services;

public interface IPropertyService
{
    Task<IReadOnlyList<PropertyModel>> GetAllProperties(CancellationToken token = default);
    Task AddProperties(string kupName, IReadOnlyList<PropertyModel> properties, CancellationToken token = default);
}