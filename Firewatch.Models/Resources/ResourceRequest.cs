using System;

namespace Firewatch.Models.Resources
{
    public class ResourceRequest
    {
        public Guid InstanceId { get; }
        public string InstanceUrlName { get; }
        public ResourceDescription ResourceDescription { get; }

        public ResourceRequest()
        {
        }

        public ResourceRequest(Guid instanceId, string instanceUrlName, ResourceDescription resourceDescription)
        {
            InstanceId = instanceId;
            InstanceUrlName = instanceUrlName;
            ResourceDescription = resourceDescription;
        }
    }
}