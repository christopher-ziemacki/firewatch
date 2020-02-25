using AutoMapper;
using Firewatch.Models.Resources;

namespace Firewatch.Data.Entities.Profiles
{
    internal class SolutionEntityProfile : Profile
    {
        public SolutionEntityProfile()
        {
            CreateMap<SolutionEntity, SolutionResource>();
        }
    }
}
