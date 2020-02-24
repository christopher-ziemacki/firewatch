using AutoMapper;
using Firewatch.Models;

namespace Firewatch.Data.Entities.Profiles
{
    internal class SystemUserEntityProfile : Profile
    {
        public SystemUserEntityProfile()
        {
            CreateMap<SystemUserEntity, SystemUser>();
        }
    }
}