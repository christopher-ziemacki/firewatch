using Firewatch.Models.Resources;

namespace Firewatch.Services.ResourceProviders
{
    public interface IResourceProviderFactory
    {
        IResourceProvider CreateResourceProvider(ResourceType resourceType);
    }
}
