using Firewatch.App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace Firewatch.App.Components
{
    public class InstanceTableRowBase : ComponentBase
    {
        [Parameter]
        public InstanceTableRowData Instance { get; set; }
    }
}
