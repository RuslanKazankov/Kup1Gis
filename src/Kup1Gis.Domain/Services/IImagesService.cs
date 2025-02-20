using Kup1Gis.Domain.Models.FileModels;

namespace Kup1Gis.Domain.Services;

public interface IImagesService
{
    Task AddImageToKup(long kupId, AddImageModel addImageModel, CancellationToken token = default);
    Task<IReadOnlyList<GetImageModel>> GetImages(long kupId, CancellationToken token = default);
}