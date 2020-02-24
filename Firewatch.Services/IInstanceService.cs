using System.Collections.Generic;
using System.Threading.Tasks;
using Firewatch.Models;

namespace Firewatch.Services
{
    public interface IInstanceService
    {
        Task<IEnumerable<Instance>> GetInstances();
    }
}
