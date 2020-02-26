using System.Collections.Generic;
using System.Linq;
using Firewatch.Models.Resources;

namespace Firewatch.Models
{
    public class FirewatchInstance
    {
        public Instance Instance { get; set; }

        public IEnumerable<ExpectedResource> ExpectedResources { get; set; }

        public IEnumerable<Resource> Resources { get; set; }

        public bool AreResourcesMissing
        {
            get
            {
                var missingResources = GetMissingResources();
                return missingResources != null && missingResources.Any();
            }
        }

        public bool DoesContextUserHaveAccess
        {
            get
            {
                return Resources.Any(resource =>
                    resource.Values.Any(kv => kv.Key == "IsContextUser" && kv.Value.Value == "true"));
            }
        }
        
        public IEnumerable<ExpectedResource> GetMissingResources()
        {
            return ExpectedResources.Where(expectedResource => expectedResource.Required != false)
                .Where(expectedResource => Resources.All(resource =>
                    resource.ResourceDescription != expectedResource.ResourceDescription)).ToList();
        }
    }
}