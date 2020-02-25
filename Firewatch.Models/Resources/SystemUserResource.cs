namespace Firewatch.Models.Resources
{
    public class SystemUserResource : Resource
    {
        public string DomainName { get; set; }
        public bool IsDisabled { get; set; }
    }
}
