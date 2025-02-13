using Kup1Gis.Domain.Models.FileModels;
using Kup1Gis.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kup1Gis.Controllers;

public class ImageController : Controller
{
    private IImagesService _imagesService;

    public ImageController(IImagesService imagesService)
    {
        _imagesService = imagesService;
    }
    
    public IActionResult AddImage(IFormFileCollection files)
    {
        foreach (var file in files)
        {
            _imagesService.AddImageToKup(0, new AddImageRequest()
            {
                FileName = file.FileName,
                FileStream = file.OpenReadStream()
            });
        }

        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}