namespace Kup1Gis.Models;

public record AddImageListRequest
{
    public required long KupId { get; set; }
    public IReadOnlyList<ImageRequest> Images { get; set; } = [];
}