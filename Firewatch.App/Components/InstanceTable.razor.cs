using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Firewatch.Models;
using Microsoft.AspNetCore.Components;

namespace Firewatch.App.Components
{
    public class InstanceTableBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<FirewatchInstance> FirewatchInstances { get; set; }

        protected string Filter { get; set; }
    }
}
