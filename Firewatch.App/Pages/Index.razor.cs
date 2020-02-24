using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Firewatch.App.ViewModels;
using Firewatch.Services;
using Microsoft.AspNetCore.Components;

namespace Firewatch.App.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject] private IInstanceService InstanceService { get; set; }
        [Inject] private ISystemUserService SystemUserService { get; set; }

        [Inject] private IMapper Mapper { get; set; }

        protected IEnumerable<InstanceTableRowData> InstanceTableData { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var instances = await InstanceService.GetInstances();

            InstanceTableData =
                instances == null
                    ? Enumerable.Empty<InstanceTableRowData>()
                    : Mapper.Map<IEnumerable<InstanceTableRowData>>(instances);


            InstanceService.GetInstances().ContinueWith(instance =>
            {

            });
        }
    }
}