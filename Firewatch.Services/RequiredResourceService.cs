using System;
using System.Collections.Generic;
using System.IO;
using Firewatch.Models.Resources;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Firewatch.Services
{
    public class RequiredResourceService : IRequiredResourceService
    {
        private readonly IResourceTypeService _resourceTypeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Lazy<IEnumerable<RequiredResource>> _requiredResources;

        private IEnumerable<RequiredResource> RequiredResources => _requiredResources.Value;

        public RequiredResourceService(IResourceTypeService resourceTypeService, IHttpContextAccessor httpContextAccessor)
        {
            _resourceTypeService = resourceTypeService ?? throw new ArgumentNullException(nameof(resourceTypeService));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
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

            var requiredResources = new List<RequiredResource>();
            foreach (var item in result)
            {
                var requiredResource = new RequiredResource()
                {
                    ResourceDescription = new ResourceDescription()
                    {
                        ResourceType = _resourceTypeService.GetResourceType(item["ResourceType"]),
                        ResourceId = item["ResourceId"]
                    }
                };
                
                var resourceTypeName = requiredResource.ResourceDescription.ResourceType.Name;
                var resourceId = requiredResource.ResourceDescription.ResourceId;

                if (resourceTypeName == "SystemUser" && resourceId == "[[ContextUser]]")
                {
                    var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
                    requiredResource.ResourceDescription.ResourceId = userName;
                }

                requiredResources.Add(requiredResource);
            }

            return requiredResources;
        }
    }
}