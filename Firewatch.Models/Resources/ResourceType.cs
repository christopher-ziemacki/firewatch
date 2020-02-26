using System;
using System.Collections.Generic;
using System.Linq;

namespace Firewatch.Models.Resources
{
    public class ResourceType
    {
        public string Name { get; set; }
        public string UriTemplate { get; set; }

        public IEnumerable<ResourceProperty> Properties { get; set; }

        public ResourceType()
        {

        }

        public ResourceType(string name, string uriTemplate, IEnumerable<ResourceProperty> resourceProperties)
        {
            Name = name;
            UriTemplate = uriTemplate;
            Properties = resourceProperties ?? throw new ArgumentNullException(nameof(resourceProperties));
        }
    }
}