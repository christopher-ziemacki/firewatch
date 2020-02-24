using System.Collections.Generic;
using System.Threading.Tasks;
using Firewatch.Models;
using Firewatch.Services;
using Microsoft.AspNetCore.Components;

namespace Firewatch.App.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject] private IFirewatchService FirewatchService { get; set; }
        
        protected IEnumerable<FirewatchInstance> FirewatchInstances { get; set; }

        protected override async Task OnInitializedAsync()
        {
            FirewatchInstances = await FirewatchService.GetInstances();
        }
    }
}