using System.Threading.Tasks;
using Firewatch.Models;
using Firewatch.Models.Resources;

namespace Firewatch.Services.ResourceProviders
{
    public interface IResourceProvider
    {
        Task<Resource> GetResource(ResourceRequest resourceRequest);
    }
}