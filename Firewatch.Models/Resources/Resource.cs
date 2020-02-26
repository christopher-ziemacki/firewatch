using System;
using System.Collections.Generic;

namespace Firewatch.Models.Resources
{
    public class Resource
    {
        public Guid InstanceId { get; set; }
        public ResourceDescription ResourceDescription { get; set; }

        public IDictionary<string, ResourceValue> Values { get; } = new Dictionary<string, ResourceValue>();
    }
}
