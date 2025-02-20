using Kup1Gis.Domain.Models.Kup;
using Kup1Gis.Domain.RepoInterfaces;

namespace Kup1Gis.Domain.Services.Implications;

public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _propertyRepository;

    public PropertyService(IPropertyRepository propertyRepository)
    {
        _propertyRepository = propertyRepository;
    }

    public async Task<IReadOnlyList<PropertyModel>> GetAllProperties(CancellationToken token = default)
    {
        return (await _propertyRepository.GetAllAsync(token))
            .Select(p => new PropertyModel
            {
                Name = p.Name,
                Value = string.Empty
            })
            .ToList();
    }
}