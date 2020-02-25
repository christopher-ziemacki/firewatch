using System.Threading.Tasks;
using Firewatch.Models.Resources;

namespace Firewatch.Data.Repositories
{
    public interface IResourceRepository
    {
        Task<Resource> GetResource(ResourceRequest resourceRequest);
    }
}
