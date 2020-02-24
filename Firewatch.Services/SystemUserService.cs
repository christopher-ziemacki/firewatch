using System;
using System.Threading.Tasks;
using Firewatch.Data.Repositories;

namespace Firewatch.Services
{
    public class SystemUserService : ISystemUserService
    {
        private readonly ISystemUserRepository _systemUserRepository;

        public SystemUserService(ISystemUserRepository systemUserRepository)
        {
            _systemUserRepository = systemUserRepository ?? throw new ArgumentNullException(nameof(systemUserRepository));
        }

        public async Task<bool> DoesUserHaveAccess(string instanceUrlName, string systemUserDomainName)
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

            var userHasAccess = systemUser != null && systemUser.IsDisabled == false;

            return userHasAccess;
        }
    }
}
