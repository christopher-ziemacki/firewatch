using System;
using Firewatch.Models;
using Microsoft.AspNetCore.Components;

namespace Firewatch.App.Components
{
    public class InstanceTableRowBase : ComponentBase
    {
        [Parameter]
        public FirewatchInstance FirewatchInstance { get; set; }

        [Parameter]
        public EventCallback<Guid> OnInstanceDetailsButtonClicked { get; set; }

        public Instance Instance => FirewatchInstance.Instance;

        protected bool Collapsed { get; set; } = true;

        public void OnExpandCollapseButtonClicked()
        {
            Collapsed = !Collapsed;

        }
    }
}
