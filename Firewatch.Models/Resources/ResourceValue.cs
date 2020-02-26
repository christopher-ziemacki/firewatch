namespace Firewatch.Models.Resources
{
    public class ResourceValue
    {
        public ResourceProperty ResourceProperty { get; }
        public string Value { get; }

        public ResourceValue(ResourceProperty resourceProperty, string value)
        {
            ResourceProperty = resourceProperty;
            Value = value;
        }
    }
}