namespace Firewatch.Models.Resources
{
    public readonly struct ResourceDescription
    {
        public ResourceDescription(ResourceType resourceType, string resourceId)
        {
            (ResourceType, ResourceId) = (resourceType, resourceId);
        }

        public ResourceType ResourceType { get; }
        public string ResourceId { get; }

        public override bool Equals(object obj) =>
            obj is ResourceDescription resourceDescription && this == resourceDescription;

        public override int GetHashCode() => ResourceType.GetHashCode() ^ ResourceId.GetHashCode();

        public static bool operator ==(ResourceDescription rd1, ResourceDescription rd2) =>
            rd1.ResourceId == rd2.ResourceId && rd1.ResourceType == rd2.ResourceType;

        public static bool operator !=(ResourceDescription rd1, ResourceDescription rd2)
            => rd1.ResourceId != rd2.ResourceId || rd1.ResourceType != rd2.ResourceType;
    }
}