using Kup1Gis.Domain.Entity;
using Kup1Gis.Domain.Entity.KupEntity;
using Kup1Gis.Domain.Entity.KupEntity.ObservationEntity;
using Kup1Gis.Domain.Models.Kup;
using Kup1Gis.Domain.RepoInterfaces;

namespace Kup1Gis.Domain.Services.Implications;

public sealed class KupService : IKupService
{
    private readonly IKupRepository _kupRepository;
    private readonly IPropertyRepository _propertyRepository;
    
    public KupService(IKupRepository kupRepository, IPropertyRepository propertyRepository)
    {
        _kupRepository = kupRepository;
        _propertyRepository = propertyRepository;
    }
    
    public async Task<long> AddKup(ObservationModel model, CancellationToken token = default)
    {
        if (model.Id == null)
        {
            if (!(await _kupRepository.ContainsNameAsync(model.Name, token)))
            {
                throw new KeyNotFoundException("Имя не найдено. Укажите Id для новой точки или уточните имя.");
            }
            return await AddObservation(model, token);
        }
        else
        {
            if ((await _kupRepository.ContainsNameAsync(model.Name, token)))
            {
                var kup = await _kupRepository.FindByNameAsync(model.Name, token);
                
                if (kup.Id != model.Id)
                    throw new KeyNotFoundException($"Имя уже используется у точки № {kup.Id}. Укажите этот Id или уберите его для нового наблюдения, или измените имя для новой точки.");
                
                return await AddObservation(model, token);
            }

            if ((await _kupRepository.ContainsIdAsync(model.Id.Value, token)))
            {
                return await AddObservationById(model, token);
            }
            await AddNewKup(model, token);
            return model.Id.Value;
        }
    }

    private async Task<long> AddObservationById(ObservationModel model, CancellationToken token = default)
    {
        if (model.Id == null)
        {
            throw new ArgumentNullException(nameof(model.Id));
        }
        Kup targetKup = await _kupRepository.FindByIdAsync(model.Id.Value, token);
        targetKup.Observations.Add(await CreateObservation(model.Properties, token));
        await _kupRepository.UpdateAsync(targetKup, token);
        return targetKup.Id;
    }

    public async Task<IReadOnlyList<ObservationModel>> GetObservations(long id, CancellationToken token = default)
    {
        Kup kup = await _kupRepository.FindAsync(id, token);

        List<ObservationModel> result = [];

        foreach (var observation in kup.Observations)
        {
            ObservationModel observationModel = new()
            {
                Id = kup.Id,
                Name = kup.Name,
                GeographicalReference = kup.GeographicalReference,
                Coordinates = new CoordinatesModel
                {
                    Latitude = kup.Coordinates.Latitude,
                    Longitude = kup.Coordinates.Longitude,
                    AbsMarkOfSea = kup.Coordinates.AbsMarkOfSea,
                    Eksp = kup.Coordinates.Eksp
                },
                Properties = observation.KupProperties
                    .Select(kp => new PropertyModel
                    {
                        Name = kp.Property.Name, 
                        Value = kp.Value
                    }).ToList()
            };
            
            result.Add(observationModel);
        }
        
        return result;
    }

    public async Task<IReadOnlyList<KupHeaderModel>> GetAllKups(CancellationToken token = default)
    {
        var allKups = await _kupRepository.GetAllAsync(token);
        List<KupHeaderModel> result = [];
        foreach (var kup in allKups)
        {
            result.Add(new KupHeaderModel
            {
                Id = kup.Id,
                Name = kup.Name,
                GeographicalReference = kup.GeographicalReference,
                Coordinates = new CoordinatesModel
                {
                    Latitude = kup.Coordinates.Latitude,
                    Longitude = kup.Coordinates.Longitude,
                    AbsMarkOfSea = kup.Coordinates.AbsMarkOfSea,
                    Eksp = kup.Coordinates.Eksp
                }
            });
        }
        return result;
    }

    private async Task<long> AddObservation(ObservationModel model, CancellationToken token = default)
    {
        Kup targetKup = await _kupRepository.FindByNameAsync(model.Name, token);
        targetKup.Observations.Add(await CreateObservation(model.Properties, token));
        await _kupRepository.UpdateAsync(targetKup, token);
        return targetKup.Id;
    }

    private async Task AddNewKup(ObservationModel model, CancellationToken token = default)
    {
        Kup newKup = new Kup
        {
            Id = model.Id!.Value,
            Name = model.Name,
            GeographicalReference = model.GeographicalReference,
            Coordinates = new Coordinates
            {
                Latitude = model.Coordinates.Latitude,
                Longitude = model.Coordinates.Longitude,
                AbsMarkOfSea = model.Coordinates.AbsMarkOfSea,
                Eksp = model.Coordinates.Eksp
            },
            Observations = [await CreateObservation(model.Properties, token)]
        };
        await _kupRepository.AddAsync(newKup, token);
    }

    private async Task<Observation> CreateObservation(IReadOnlyList<PropertyModel> properties, CancellationToken token = default)
    {
        List<KupProperty> kupProperties = [];
        foreach (var property in properties)
        {
            kupProperties.Add(new KupProperty
            {
                Property = await _propertyRepository.FindByNameAsync(property.Name, token),
                Value = property.Value
            });
        }
        
        return new Observation
        {
            KupProperties = kupProperties
        };;
    }
}