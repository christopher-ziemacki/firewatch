using AutoMapper;
using Firewatch.Data.Repositories;
using Firewatch.Models;
using Firewatch.Models.Resources;

namespace Firewatch.Services.ResourceProviders
{
    public class SystemUserProvider : AbstractProvider<ISystemUserRepository, SystemUserResource>, ISystemUserProvider
    {
        public SystemUserProvider(ISystemUserRepository systemUserRepository) : base(systemUserRepository)
        {

        }
    }
}
