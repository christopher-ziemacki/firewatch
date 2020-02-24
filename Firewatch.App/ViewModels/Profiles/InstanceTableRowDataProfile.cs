using AutoMapper;
using Firewatch.Models;

namespace Firewatch.App.ViewModels.Profiles
{
    public class InstanceTableRowDataProfile : Profile
    {
        public InstanceTableRowDataProfile()
        {
            CreateMap<Instance, InstanceTableRowData>();
        }
    }
}
