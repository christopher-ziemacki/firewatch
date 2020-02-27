using System;
using System.Collections.Generic;
using Firewatch.Models;
using Microsoft.AspNetCore.Components;

namespace Firewatch.App.Components
{
    public class InstanceTableBase : ComponentBase
    {
        [Parameter] public IEnumerable<FirewatchInstance> FirewatchInstances { get; set; }

        [Parameter] public EventCallback<Guid> OnInstanceDetailsButtonClicked { get; set; }

        protected string Filter { get; set; }
    }
}