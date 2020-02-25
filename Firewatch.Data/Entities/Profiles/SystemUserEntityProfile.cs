using AutoMapper;
using Firewatch.Models.Resources;

namespace Firewatch.Data.Entities.Profiles
{
    internal class SystemUserEntityProfile : Profile
    {
        public SystemUserEntityProfile()
        {
            CreateMap<SystemUserEntity, SystemUserResource>().ForMember(
                dst => dst.InstanceId,
                opt => opt.MapFrom(src => src.OrganizationId)
            );
        }
    }
}