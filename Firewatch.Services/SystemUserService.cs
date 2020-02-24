using System;
using System.Threading.Tasks;
using Firewatch.Data.Repositories;
using Firewatch.Models;

namespace Firewatch.Services
{
    public class SystemUserService : ISystemUserService
    {
        private readonly ISystemUserRepository _systemUserRepository;

        public SystemUserService(ISystemUserRepository systemUserRepository)
        {
            _systemUserRepository = systemUserRepository ?? throw new ArgumentNullException(nameof(systemUserRepository));
        }

        public async Task<SystemUser> GetSystemUser(string instanceUrlName, string systemUserDomainName)
        {
            if (instanceUrlName == null)
            {
                throw new ArgumentNullException(nameof(instanceUrlName));
            }

            if (systemUserDomainName == null)
            {
                throw new ArgumentNullException(nameof(systemUserDomainName));
            }

            var systemUser = await _systemUserRepository.GetSystemUser(instanceUrlName, systemUserDomainName);
            return systemUser;
        }
    }
}
