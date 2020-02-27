using System;
using System.Threading.Tasks;
using Firewatch.Models;
using Firewatch.Services;
using Microsoft.AspNetCore.Components;

namespace Firewatch.App.Pages
{
    public class InstanceBase : ComponentBase
    {
        [Inject] protected IFirewatchService FirewatchService { get; set; }

        [Parameter]
        public Guid InstanceId { get; set; }

        protected FirewatchInstance FirewatchInstance { get; set; }

        protected override async Task OnInitializedAsync()
        {
            FirewatchInstance = await FirewatchService.GetFirewatchInstance(InstanceId);

            await base.OnInitializedAsync();
        }
    }
}
