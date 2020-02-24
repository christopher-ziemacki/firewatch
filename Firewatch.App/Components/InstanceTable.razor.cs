using System.Collections.Generic;
using Firewatch.App.Models;
using Microsoft.AspNetCore.Components;

namespace Firewatch.App.Components
{
    public class InstanceTableBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<Instance> Instances { get; set; }
    }
}
