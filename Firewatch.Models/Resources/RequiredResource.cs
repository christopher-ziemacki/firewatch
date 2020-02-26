namespace Firewatch.Models.Resources
{
    public class RequiredResource
    {
        public ResourceDescription ResourceDescription { get; set; }

        public RequiredResource()
        {
            
        }

        public RequiredResource(ResourceDescription resourceDescription)
        {
            ResourceDescription = resourceDescription;
        }
    }
}