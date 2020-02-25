using AutoMapper;
using Firewatch.Models;
using Firewatch.Models.Resources;

namespace Firewatch.Data.Entities.Profiles
{
    internal class SolutionEntityProfile : Profile
    {
        public SolutionEntityProfile()
        {
            CreateMap<SolutionEntity, SolutionResource>().ForMember(
                dst => dst.InstanceId,
                opt => opt.MapFrom(src => src.OrganizationId)
            );
        }
    }
}
