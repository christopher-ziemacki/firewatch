using Firewatch.Models;
using Microsoft.AspNetCore.Components;

namespace Firewatch.App.Components
{
    public class InstanceTableRowBase : ComponentBase
    {
        [Parameter]
        public FirewatchInstance FirewatchInstance { get; set; }

        public Instance Instance => FirewatchInstance.Instance;
    }
}
