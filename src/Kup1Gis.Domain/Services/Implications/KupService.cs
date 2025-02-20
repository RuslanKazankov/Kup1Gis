using Kup1Gis.Domain.Entity;
using Kup1Gis.Domain.Entity.KupEntity;
using Kup1Gis.Domain.Entity.KupEntity.ObservationEntity;
using Kup1Gis.Domain.Models.Kup;
using Kup1Gis.Domain.RepoInterfaces;

namespace Kup1Gis.Domain.Services.Implications;

public sealed class KupService : IKupService
{
    private readonly IImagesService _imagesService;
    private readonly IKupRepository _kupRepository;
    private readonly IObservationRepository _observationRepository;
    private readonly IPropertyRepository _propertyRepository;

    public KupService(
        IKupRepository kupRepository,
        IPropertyRepository propertyRepository,
        IObservationRepository observationRepository,
        IImagesService imagesService)
    {
        _kupRepository = kupRepository;
        _propertyRepository = propertyRepository;
        _observationRepository = observationRepository;
        _imagesService = imagesService;
    }

    public async Task<long> AddKup(KupHeadModel model, CancellationToken token = default)
    {
        var kup = new Kup
        {
            Id = model.Id,
            Name = model.Name,
            GeographicalReference = model.GeographicalReference ?? string.Empty,
            Coordinates = new Coordinates
            {
                Latitude = model.Coordinates.Latitude,
                Longitude = model.Coordinates.Longitude,
                AbsMarkOfSea = model.Coordinates.AbsMarkOfSea,
                Eksp = model.Coordinates.Eksp ?? string.Empty
            }
        };
        await _kupRepository.AddAsync(kup, token);

        return kup.Id;
    }

    public async Task<FullKupModel> GetFullKup(long id, CancellationToken token = default)
    {
        var kup = await _kupRepository.FindByIdAsync(id, token);
        List<ObservationModel> observationModels = [];
        foreach (var observation in kup.Observations)
            observationModels.Add(new ObservationModel
            {
                Name = kup.Name,
                Properties = observation.KupProperties
                    .Select(kp => new PropertyModel
                    {
                        Name = kp.Property.Name,
                        Value = kp.Value
                    }).ToList()
            });

        var kupResult = new FullKupModel
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
            Observations = observationModels,
            KupImages = await _imagesService.GetImages(kup.Id, token)
        };
        return kupResult;
    }

    public async Task<long> AddObservation(ObservationModel model, CancellationToken token = default)
    {
        var kup = await _kupRepository.FindByNameAsync(model.Name, token);

        List<KupProperty> kupProperties = [];
        foreach (var property in model.Properties)
            kupProperties.Add(new KupProperty
            {
                Property = await _propertyRepository.FindByNameAsync(property.Name, token),
                Value = property.Value
            });
        await _observationRepository.AddAsync(new Observation
        {
            KupId = kup.Id,
            KupProperties = kupProperties
        }, token);

        return kup.Id;
    }

    public async Task<IReadOnlyList<ObservationModel>> GetObservations(long kupId, CancellationToken token = default)
    {
        var kup = await _kupRepository.FindAsync(kupId, token);

        List<ObservationModel> result = [];

        foreach (var observation in kup.Observations)
        {
            ObservationModel observationModel = new()
            {
                Name = kup.Name,
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

    public async Task<IReadOnlyList<KupHeadModel>> GetAllKups(CancellationToken token = default)
    {
        var allKups = await _kupRepository.GetAllAsync(token);
        List<KupHeadModel> result = [];
        foreach (var kup in allKups)
            result.Add(new KupHeadModel
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
        return result;
    }
}