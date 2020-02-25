namespace Firewatch.Models.Resources
{
    public readonly struct ResourceDescription
    {
        public ResourceDescription(ResourceType resourceType, string resourceName)
        {
            (ResourceType, ResourceName) = (resourceType, resourceName);
        }

        public ResourceType ResourceType { get; }
        public string ResourceName { get; }

        public override bool Equals(object obj) =>
            obj is ResourceDescription resourceDescription && this == resourceDescription;

        public override int GetHashCode() => ResourceType.GetHashCode() ^ ResourceName.GetHashCode();

        public static bool operator ==(ResourceDescription rd1, ResourceDescription rd2) =>
            rd1.ResourceName == rd2.ResourceName && rd1.ResourceType == rd2.ResourceType;

        public static bool operator !=(ResourceDescription rd1, ResourceDescription rd2)
            => rd1.ResourceName != rd2.ResourceName || rd1.ResourceType != rd2.ResourceType;
    }
}