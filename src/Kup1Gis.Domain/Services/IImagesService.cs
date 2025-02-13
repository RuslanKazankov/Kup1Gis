using System.Collections.ObjectModel;
using Kup1Gis.Domain.DirectorySystem;
using Kup1Gis.Domain.Entity.KupEntity;
using Kup1Gis.Domain.Models.FileModels;
using Kup1Gis.Domain.Models.Kup;

namespace Kup1Gis.Domain.Services;

public interface IImagesService
{
    Task AddImageToKup(long kupId, AddImageRequest addImageRequest, CancellationToken token = default);
    Task<IReadOnlyList<ImageModel>> GetImages(long kupId, CancellationToken token = default);
}