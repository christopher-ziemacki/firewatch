using System.Collections.Generic;
using System.Linq;
using Firewatch.Models.Resources;

namespace Firewatch.Models
{
    public class FirewatchInstance
    {
        public Instance Instance { get; set; }

        public IEnumerable<RequiredResource> RequiredResources { get; set; }

        public IEnumerable<Resource> Resources { get; set; }

        public IEnumerable<RequiredResource> MissingRequiredResources()
        {
            var missingRequiredResources = RequiredResources.All(requiredResource =>
                Resources.All(resource => resource.ResourceDescription != requiredResource.ResourceDescription));
            
            return null;
        }
    }
}