namespace Firewatch.Models.Resources
{
    public class ResourceDescription
    {
        public ResourceType ResourceType { get; set; }
        public string ResourceId { get; set; }

        public ResourceDescription()
        {
        }

        public ResourceDescription(ResourceType resourceType, string resourceId)
        {
            (ResourceType, ResourceId) = (resourceType, resourceId);
        }
    }
}