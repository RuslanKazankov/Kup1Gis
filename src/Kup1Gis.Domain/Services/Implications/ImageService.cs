using System.Collections.ObjectModel;
using Kup1Gis.Domain.DirectorySystem.Files.User;
using Kup1Gis.Domain.DirectorySystem.Interfaces;
using Kup1Gis.Domain.Entity;
using Kup1Gis.Domain.Entity.KupEntity;
using Kup1Gis.Domain.Models.FileModels;
using Kup1Gis.Domain.RepoInterfaces;

namespace Kup1Gis.Domain.Services.Implications;

public class ImageService : IImagesService
{
    private readonly ImageFolder _imageFolder;
    private readonly IKupImageRepository _kupImageRepository;
    private readonly IKupRepository _kupRepository;
    
    private const string KupImagesFolder = "KupImages";
    
    public ImageService(
        IImageFolderSource imageFolderSource,
        IKupImageRepository kupImageRepository,
        IKupRepository kupRepository)
    {
        _imageFolder = imageFolderSource.GetImageFolder();
        _kupImageRepository = kupImageRepository;
        _kupRepository = kupRepository;
    }

    public async Task AddImageToKup(long kupId, AddImageRequest addImageRequest, CancellationToken token = default)
    {
        string imagePath = GetKupImagePath(kupId, addImageRequest.FileName);
        if (File.Exists(imagePath))
        {
            throw new FileLoadException($"File already exists at {imagePath}");
        }
        
        Kup kup = await _kupRepository.FindByIdAsync(kupId, token);
        await _kupImageRepository.AddAsync(new KupImage
        {
            FileName = addImageRequest.FileName,
            Description = addImageRequest.Description ?? string.Empty,
            KupId = kupId,
            Kup = kup
        }, token);
            
        await using FileStream fileStream = new FileStream(imagePath, FileMode.Create);
        await addImageRequest.FileStream.CopyToAsync(fileStream, token);
    }

    public async Task<IReadOnlyList<ImageModel>> GetImages(long kupId, CancellationToken token = default)
    {
        List<ImageModel> images = [];
        Kup kup = await _kupRepository.FindByIdAsync(kupId, token);
        foreach (KupImage kupImage in kup.KupImages)
        {
            ImageModel imageModel = new ImageModel
            {
                FileName = kupImage.FileName,
                Path = GetKupImagePath(kupImage.KupId, kupImage.FileName),
                Description = kupImage.Description
            };
            
            images.Add(imageModel);
        }

        return images.AsReadOnly();
    }

    private string GetKupImagePath(long kupId, string filename)
    {
        return Path.Combine(GetTargetFolder(kupId), filename);
    }

    private string GetTargetFolder(long kupId)
    {
        string targetFolder = Path.Combine(_imageFolder.DirectoryInfo.FullName, KupImagesFolder, kupId.ToString());
        Directory.CreateDirectory(targetFolder);
        return targetFolder;
    }
}