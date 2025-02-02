using Kup1Gis.Domain.Entity;
using Kup1Gis.Domain.Models.Kup;

namespace Kup1Gis.Domain.Services;

public interface IPropertyService
{
    Task<IReadOnlyList<PropertyModel>> GetAllProperties();
}