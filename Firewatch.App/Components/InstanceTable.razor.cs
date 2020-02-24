using System.Collections.Generic;
using Firewatch.App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace Firewatch.App.Components
{
    public class InstanceTableBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<InstanceTableRowData> Instances { get; set; }
    }
}
