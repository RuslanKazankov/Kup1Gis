using Kup1Gis.Domain.DirectorySystem.Files.User;
using Kup1Gis.Domain.DirectorySystem.Interfaces;
using Kup1Gis.Domain.Entity.KupEntity;
using Kup1Gis.Domain.Models.FileModels;
using Kup1Gis.Domain.RepoInterfaces;

namespace Kup1Gis.Domain.Services.Implications;

public class ImageService : IImagesService
{
    private const string KupImagesFolder = "KupImages";
    private readonly ImageFolder _imageFolder;
    private readonly IKupImageRepository _kupImageRepository;
    private readonly IKupRepository _kupRepository;

    public ImageService(
        IImageFolderSource imageFolderSource,
        IKupImageRepository kupImageRepository,
        IKupRepository kupRepository)
    {
        _imageFolder = imageFolderSource.GetImageFolder();
        _kupImageRepository = kupImageRepository;
        _kupRepository = kupRepository;
    }

    public async Task AddImageToKup(long kupId, AddImageModel addImageModel, CancellationToken token = default)
    {
        var imagePath = GetKupImagePath(kupId, addImageModel.FileName);
        if (File.Exists(imagePath)) throw new FileLoadException($"File already exists at {imagePath}");

        var kup = await _kupRepository.FindByIdAsync(kupId, token);
        await _kupImageRepository.AddAsync(new KupImage
        {
            FileName = addImageModel.FileName,
            Description = addImageModel.Description ?? string.Empty,
            KupId = kupId,
            Kup = kup
        }, token);

        await using var fileStream = new FileStream(imagePath, FileMode.Create);
        await addImageModel.FileStream.CopyToAsync(fileStream, token);
    }

    public async Task<IReadOnlyList<GetImageModel>> GetImages(long kupId, CancellationToken token = default)
    {
        List<GetImageModel> images = [];
        var kup = await _kupRepository.FindByIdAsync(kupId, token);
        foreach (var kupImage in kup.KupImages)
        {
            var getImageModel = new GetImageModel
            {
                FileName = kupImage.FileName,
                Path = GetKupImagePath(kupImage.KupId, kupImage.FileName),
                Description = kupImage.Description
            };

            images.Add(getImageModel);
        }

        return images.AsReadOnly();
    }

    private string GetKupImagePath(long kupId, string filename)
    {
        return Path.Combine(GetTargetFolder(kupId), filename);
    }

    private string GetTargetFolder(long kupId)
    {
        var targetFolder = Path.Combine(_imageFolder.DirectoryInfo.FullName, KupImagesFolder, kupId.ToString());
        Directory.CreateDirectory(targetFolder);
        return targetFolder;
    }
}