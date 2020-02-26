using System.Threading.Tasks;
using Firewatch.Models.Resources;

namespace Firewatch.Services
{
    public interface IResourceProvider
    {
        Task<Resource> GetResource(ResourceRequest resourceRequest);
    }
}