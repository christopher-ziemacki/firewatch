using System;

namespace Firewatch.Models.Resources
{
    public class ResourceDescription
    {
        public ResourceType ResourceType { get; }
        public string ResourceId { get; }

        public ResourceDescription()
        {
        }

        public ResourceDescription(ResourceType resourceType, string resourceId)
        {
            (ResourceType, ResourceId) = (resourceType, resourceId);
        }

        public override bool Equals(object obj)
        {
            if (obj is ResourceDescription == false)
            {
                return false;
            }

            return this == (ResourceDescription)obj;
        }

        public override int GetHashCode()
        {
            return ResourceType.GetHashCode() ^ ResourceId.GetHashCode();
        }

        public static bool operator ==(ResourceDescription rd1, ResourceDescription rd2)
        {
            if (rd1 == null && rd2 == null)
            {
                return true;
            }

            if (rd1 == null || rd2 == null)
            {
                return false;
            }

            return rd1.ResourceType == rd2.ResourceType && rd1.ResourceId == rd2.ResourceId;
        }

        public static bool operator !=(ResourceDescription rd1, ResourceDescription rd2)
        {
            return !(rd1 == rd2);
        }
    }
}