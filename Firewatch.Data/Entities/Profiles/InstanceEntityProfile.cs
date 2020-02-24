using System;
using AutoMapper;
using Firewatch.Models;

namespace Firewatch.Data.Entities.Profiles
{
    public class InstanceEntityProfile : Profile
    {
        public InstanceEntityProfile()
        {
            CreateMap<InstanceEntity, Instance>().ForMember(
                dst => dst.Url,
                opt => opt.MapFrom(src => new Uri(src.Url))
            );
        }
    }
}
