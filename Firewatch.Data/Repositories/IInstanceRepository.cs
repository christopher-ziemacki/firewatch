using System.Collections.Generic;
using System.Threading.Tasks;
using Firewatch.Models;

namespace Firewatch.Data.Repositories
{
    public interface IInstanceRepository
    {
        Task<IEnumerable<Instance>> GetInstances();
    }
}
