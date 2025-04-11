using Kup1Gis.Domain.Entity;
using Kup1Gis.Domain.Entity.KupEntity;
using Kup1Gis.Domain.Entity.KupEntity.ObservationEntity;
using Kup1Gis.Domain.Entity.KupEntity.ObservationEntity.KupPropertyEntity;
using Kup1Gis.Domain.Models.FileModels;
using Kup1Gis.Domain.Models.Kup;
using Kup1Gis.Domain.RepoInterfaces;
using NPOI.Util.Collections;

namespace Kup1Gis.Domain.Services.Implications;

public sealed class KupService : IKupService
{
    private readonly IImagesService _imagesService;
    private readonly IKupRepository _kupRepository;
    private readonly IPropertyRepository _propertyRepository;

    public KupService(
        IKupRepository kupRepository,
        IPropertyRepository propertyRepository,
        IImagesService imagesService)
    {
        _kupRepository = kupRepository;
        _propertyRepository = propertyRepository;
        _imagesService = imagesService;
    }

    public async Task<long> AddKup(KupHeadModel model, CancellationToken token = default)
    {
        var baseProperties = await _propertyRepository.GetAllAsync(token);
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
            },
            Properties = baseProperties.Select(bp => new KupProperty(){ PropertyId = bp.Id, Values = [] }).ToList()
        };
        await _kupRepository.AddAsync(kup, token);

        return kup.Id;
    }

    public async Task<FullKupModel> GetFullKup(long id, CancellationToken token = default)
    {
        var kup = await _kupRepository.FindByIdAsync(id, token);

        return KupToFullModel(kup);
    }

    private FullKupModel KupToFullModel(Kup kup)
    {
        var modelProperties = kup.Properties.Select(FilterProperty).ToList();

        var model = new FullKupModel
        {
            Id = kup.Id,
            Name = kup.Name,
            GeographicalReference = kup.GeographicalReference ?? string.Empty,
            Coordinates = new CoordinatesModel()
            {
                Latitude = kup.Coordinates.Latitude,
                Longitude = kup.Coordinates.Longitude,
                AbsMarkOfSea = kup.Coordinates.AbsMarkOfSea,
                Eksp = kup.Coordinates.Eksp ?? string.Empty
            },
            KupImages = [],
            KupProperties = modelProperties
        };

        return model;
    }

    public async Task<IReadOnlyList<FullKupModel>> GetAllFullKups(CancellationToken token = default)
    {
        var kups = await _kupRepository.GetAllAsync(token);

        return kups.Select(KupToFullModel).ToList();
    }

    private PropertyModel FilterProperty(KupProperty property)
    {
        if (property.PropertyId == 4) // Индекс
        {
            return new PropertyModel()
            {
                Name = property.Property.Name, 
                Value = [property.Values.FirstOrDefault()?.Value ?? ""]
            };
        }
        
        return new PropertyModel()
        {
            Name = property.Property.Name, 
            Value = property.Values.Select(v => v.Value).ToList()
        };
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