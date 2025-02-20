using Kup1Gis.Domain.Models.FileModels;
using Kup1Gis.Domain.Services;
using Kup1Gis.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kup1Gis.Controllers;

public class ImageController : Controller
{
    private readonly IImagesService _imagesService;

    public ImageController(IImagesService imagesService)
    {
        _imagesService = imagesService;
    }
    
    [HttpPost]
    public IActionResult AddImage(AddImageListRequest request)
    {
        foreach (var file in request.Images)
        {
            _imagesService.AddImageToKup(request.KupId, new AddImageModel()
            {
                FileName = string.IsNullOrEmpty(file.Title?.Trim()) ? file.Image.FileName : file.Title.Trim(),
                FileStream = file.Image.OpenReadStream(),
                Description = file.Description
            });
        }

        return Ok();
    }
}