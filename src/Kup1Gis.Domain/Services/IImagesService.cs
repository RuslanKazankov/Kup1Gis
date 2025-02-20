using System.Collections.ObjectModel;
using Kup1Gis.Domain.DirectorySystem;
using Kup1Gis.Domain.Entity.KupEntity;
using Kup1Gis.Domain.Models.FileModels;
using Kup1Gis.Domain.Models.Kup;

namespace Kup1Gis.Domain.Services;

public interface IImagesService
{
    Task AddImageToKup(long kupId, AddImageModel addImageModel, CancellationToken token = default);
    Task<IReadOnlyList<GetImageModel>> GetImages(long kupId, CancellationToken token = default);
}