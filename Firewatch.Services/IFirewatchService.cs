using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firewatch.Models;

namespace Firewatch.Services
{
    public interface IFirewatchService
    {
        Task<FirewatchInstance> GetFirewatchInstance(Guid instanceId);
        Task<IEnumerable<FirewatchInstance>> GetFirewatchInstances();
    }
}
