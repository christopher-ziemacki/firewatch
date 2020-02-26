using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Firewatch.Models.Resources;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Firewatch.Services
{
    public class ResourceTypeService : IResourceTypeService
    {
        private readonly IConfiguration _configuration;

        private readonly Lazy<IDictionary<string, ResourceType>> _resourceTypes;

        private IDictionary<string, ResourceType> ResourceTypes => _resourceTypes.Value;

        public ResourceTypeService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _resourceTypes = new Lazy<IDictionary<string, ResourceType>>(LoadResourceTypes);
        }

        public ResourceType GetResourceType(string name)
        {
            var resourceType = ResourceTypes[name];
            return resourceType;
        }

        private IDictionary<string, ResourceType> LoadResourceTypes()
        {
            using var sr = new StreamReader("resourcetypes.json");
            var content = sr.ReadToEnd();
            
            var result = JsonConvert.DeserializeObject<IEnumerable<ResourceType>>(content)
                .ToDictionary(type => type.Name, type => type);
            
            return result;
        }

        private class ResourceTypeCollection
        {
            public IEnumerable<ResourceType> ResourceTypes { get; set; }
        }
    }
}