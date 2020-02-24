using System.Collections.Generic;
using Firewatch.Models;
using Microsoft.AspNetCore.Components;

namespace Firewatch.App.Components
{
    public class InstanceTableBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<FirewatchInstance> FirewatchInstances { get; set; }
    }
}
