using System.Collections.Generic;
using System.Threading.Tasks;
using Firewatch.Models;

namespace Firewatch.Services
{
    public interface IFirewatchService
    {
        Task<IEnumerable<FirewatchInstance>> GetInstances();
    }
}
