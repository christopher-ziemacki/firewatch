using System.Threading.Tasks;
using Firewatch.Models;
using Firewatch.Models.Resources;

namespace Firewatch.Data.Repositories
{
    public interface IResourceRepository<T> where T : Resource
    {
        Task<T> GetResource(string instanceUrlName, string resourceName);
    }
}
