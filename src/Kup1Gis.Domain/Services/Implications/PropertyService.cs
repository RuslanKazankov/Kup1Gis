using Kup1Gis.Domain.Entity.KupEntity.ObservationEntity;
using Kup1Gis.Domain.Entity.KupEntity.ObservationEntity.KupPropertyEntity;
using Kup1Gis.Domain.Models.Kup;
using Kup1Gis.Domain.RepoInterfaces;

namespace Kup1Gis.Domain.Services.Implications;

public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IKupRepository _kupRepository;

    public PropertyService(
        IPropertyRepository propertyRepository,
        IKupRepository kupRepository)
    {
        _kupRepository = kupRepository;
        _propertyRepository = propertyRepository;
    }

    public async Task<IReadOnlyList<PropertyModel>> GetAllProperties(CancellationToken token = default)
    {
        return (await _propertyRepository.GetAllAsync(token))
            .Select(p => new PropertyModel
            {
                Name = p.Name,
                Value = []
            })
            .ToList();
    }

    public async Task AddProperties(string kupName, IReadOnlyList<PropertyModel> properties, CancellationToken token = default)
    {
        var kup = await _kupRepository.FindByNameAsync(kupName, token);

        foreach (var property in properties)
        {
            KupProperty kupProperty = kup.Properties.First(p => p.Property.Name == property.Name);
            kupProperty.Values.AddRange(property.Value.Select(s => new PropertyValue() { Value = s }));
        }
        
        await _kupRepository.UpdateAsync(kup, token);
    }
}