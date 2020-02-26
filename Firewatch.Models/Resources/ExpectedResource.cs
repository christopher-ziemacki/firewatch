namespace Firewatch.Models.Resources
{
    public class ExpectedResource
    {
        public ResourceDescription ResourceDescription { get; set; }

        public bool Required { get; set; }

        public ExpectedResource()
        {
            
        }

        public ExpectedResource(ResourceDescription resourceDescription, bool required)
        {
            ResourceDescription = resourceDescription;
            Required = required;
        }
    }
}