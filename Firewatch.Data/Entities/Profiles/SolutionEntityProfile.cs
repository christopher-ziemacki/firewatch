using AutoMapper;
using Firewatch.Models;

namespace Firewatch.Data.Entities.Profiles
{
    internal class SolutionEntityProfile : Profile
    {
        public SolutionEntityProfile()
        {
            CreateMap<SolutionEntity, Solution>();
        }
    }
}
