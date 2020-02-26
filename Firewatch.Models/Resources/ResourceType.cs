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

        public override bool Equals(object obj)
        {
            if (obj is ResourceType == false)
            {
                return false;
            }

            return this == (ResourceType)obj;
        }

        public static bool operator ==(ResourceType rt1, ResourceType rt2)
        {
            if (rt1 is null && rt2 is null)
            {
                return true;
            }

            if (rt1 is null || rt2 is null)
            {
                return false;
            }

            return rt1.Name == rt2.Name && rt1.UriTemplate == rt2.UriTemplate;
        }

        public static bool operator !=(ResourceType rt1, ResourceType rt2)
        {
            return !(rt1 == rt2);
        }
    }
}