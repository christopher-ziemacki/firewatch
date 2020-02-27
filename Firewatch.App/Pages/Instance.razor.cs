using System;
using System.Threading.Tasks;
using Firewatch.Services;
using Microsoft.AspNetCore.Components;

namespace Firewatch.App.Pages
{
    public class InstanceBase : ComponentBase
    {
        [Inject] protected IFirewatchService FirewatchService { get; set; }

        [Parameter]
        public Guid InstanceId { get; set; }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
    }
}
