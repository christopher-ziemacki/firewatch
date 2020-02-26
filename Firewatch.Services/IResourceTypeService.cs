using Firewatch.Models.Resources;

namespace Firewatch.Services
{
    public interface IResourceTypeService
    {
        ResourceType GetResourceType(string name);
    }
}
