namespace Firewatch.Models.Resources
{
    public class ResourceProperty
    {
        public string JsonProperty { get; set; }
        public string Name { get; set; }
        
        public ResourceProperty()
        {
            
        }

        public ResourceProperty(string jsonProperty, string name)
        {
            JsonProperty = jsonProperty;
            Name = name;
        }
    }
}
