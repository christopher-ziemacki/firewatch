using Firewatch.App.Models;
using Microsoft.AspNetCore.Components;

namespace Firewatch.App.Components
{
    public class InstanceTableRowBase : ComponentBase
    {
        [Parameter]
        public Instance Instance { get; set; }
    }
}
