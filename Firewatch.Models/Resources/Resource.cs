using System;

namespace Firewatch.Models.Resources
{
    public class Resource
    {
        public Guid InstanceId { get; set; }
        public ResourceType ResourceType { get; set; }
    }
}
