namespace Firewatch.Models.Resources
{
    public class SystemUserResource : Resource
    {
        public static readonly ResourceType SystemUserResourceType = new ResourceType("SystemUser",
            "{0}/api/data/v9.0/systemusers?$filter=domainname eq '{1}'",
            "Firewatch.Models.Resources.SystemUserResource");

        public string DomainName { get; set; }
        public bool IsDisabled { get; set; }

        public SystemUserResource()
        {
            ResourceType = SystemUserResourceType;
        }
    }
}