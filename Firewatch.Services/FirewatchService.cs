using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firewatch.Models;
using Microsoft.AspNetCore.Http;

namespace Firewatch.Services
{
    public class FirewatchService : IFirewatchService
    {
        private readonly IInstanceService _instanceService;
        private readonly ISystemUserService _systemUserService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FirewatchService(IInstanceService instanceService, ISystemUserService systemUserService,
            IHttpContextAccessor httpContextAccessor)
        {
            _instanceService = instanceService ?? throw new ArgumentNullException(nameof(instanceService));
            _systemUserService = systemUserService ?? throw new ArgumentNullException(nameof(systemUserService));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<IEnumerable<FirewatchInstance>> GetFirewatchInstances()
        {
            var instances = await _instanceService.GetInstances();

            var tasks = new List<Task>();
            var firewatchInstances = instances.Select(instance =>
            {
                var firewatchInstance = new FirewatchInstance()
                {
                    Instance = instance
                };

                var getTeamAdminTask = _systemUserService
                    .GetSystemUser(firewatchInstance.Instance.UrlName, "teklaad\\crmteamadmin")
                    .ContinueWith(t => { firewatchInstance.TeamAdminUser = t.Result; });

                tasks.Add(getTeamAdminTask);

                var contextUserName = _httpContextAccessor.HttpContext.User.Identity.Name;
                var getContextUserTask = _systemUserService
                    .GetSystemUser(firewatchInstance.Instance.UrlName, contextUserName)
                    .ContinueWith(t => { firewatchInstance.ContextUser = t.Result; });

                tasks.Add(getContextUserTask);

                return firewatchInstance;
            }).ToArray();

            await Task.WhenAll(tasks);

            return firewatchInstances;
        }

        public async Task<FirewatchInstance> GetFirewatchInstance()
        {
            return default;
        }
    }
}