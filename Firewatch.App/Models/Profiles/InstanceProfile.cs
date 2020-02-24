using AutoMapper;

namespace Firewatch.App.Models.Profiles
{
    public class InstanceProfile : Profile
    {
        public InstanceProfile()
        {
            CreateMap<Firewatch.Models.Instance, Instance>();
        }
    }
}
