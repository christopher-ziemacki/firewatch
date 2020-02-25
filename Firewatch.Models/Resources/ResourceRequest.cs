using System;

namespace Firewatch.Models.Resources
{
    public readonly struct ResourceRequest
    {
        public ResourceRequest(Guid instanceId, string instanceUrlName, ResourceDescription resourceDescription)
        {
            InstanceId = instanceId;
            InstanceUrlName = instanceUrlName;
            ResourceDescription = resourceDescription;
        }

        public Guid InstanceId { get; }
        public string InstanceUrlName { get; }
        public ResourceDescription ResourceDescription { get; }

        public override bool Equals(object obj) =>
            obj is ResourceRequest resourceRequest && this == resourceRequest;

        public override int GetHashCode() => InstanceId.GetHashCode() ^ InstanceUrlName.GetHashCode() ^
                                             ResourceDescription.GetHashCode();

        public static bool operator ==(ResourceRequest rr1, ResourceRequest rr2) =>
            rr1.InstanceId == rr2.InstanceId && rr1.InstanceUrlName == rr2.InstanceUrlName &&
            rr1.ResourceDescription == rr2.ResourceDescription;

        public static bool operator !=(ResourceRequest rr1, ResourceRequest rr2) =>
            rr1.InstanceId != rr2.InstanceId || rr1.InstanceUrlName != rr2.InstanceUrlName ||
            rr1.ResourceDescription != rr2.ResourceDescription;
    }
}