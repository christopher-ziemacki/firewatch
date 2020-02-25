namespace Firewatch.Models.Resources
{
    public class SolutionResource : Resource
    {
        public static readonly ResourceType SolutionResourceType = new ResourceType("Solution",
            "{0}/api/data/v9.0/solutions?$filter=uniquename eq '{1}'",
            "Firewatch.Models.Resources.SolutionResource");

        public string UniqueName { get; set; }
        public string Version { get; set; }

        public SolutionResource()
        {
            ResourceType = SolutionResourceType;
        }
    }
}