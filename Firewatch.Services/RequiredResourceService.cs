using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Firewatch.Models.Resources;
using Newtonsoft.Json;

namespace Firewatch.Services
{
    public class RequiredResourceService : IRequiredResourceService
    {
        private readonly IResourceTypeService _resourceTypeService;
        private readonly Lazy<IEnumerable<RequiredResource>> _requiredResources;

        private IEnumerable<RequiredResource> RequiredResources => _requiredResources.Value;

        public RequiredResourceService(IResourceTypeService resourceTypeService)
        {
            _resourceTypeService = resourceTypeService ?? throw new ArgumentNullException(nameof(resourceTypeService));
            _requiredResources = new Lazy<IEnumerable<RequiredResource>>(LoadRequiredResources);
        }

        public IEnumerable<RequiredResource> GetRequiredResources()
        {
            return RequiredResources;
        }

        private IEnumerable<RequiredResource> LoadRequiredResources()
        {
            using var sr = new StreamReader("requiredresources.json");
            var content = sr.ReadToEnd();

            var result = JsonConvert.DeserializeObject<IEnumerable<IDictionary<string, string>>>(content);

            return result.Select(item => new RequiredResource()
                {
                    ResourceDescription = new ResourceDescription()
                    {
                        ResourceType = _resourceTypeService.GetResourceType(item["ResourceType"]),
                        ResourceId = item["ResourceId"]
                    }
                })
                .ToList();
        }
    }
}