using System;
using System.Collections.Generic;
using System.IO;
using Firewatch.Models.Resources;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Firewatch.Services
{
    public class ExpectedResourceService : IExpectedResourceService
    {
        private readonly IResourceTypeService _resourceTypeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Lazy<IEnumerable<ExpectedResource>> _expectedResources;

        private IEnumerable<ExpectedResource> ExpectedResources => _expectedResources.Value;

        public ExpectedResourceService(IResourceTypeService resourceTypeService,
            IHttpContextAccessor httpContextAccessor)
        {
            _resourceTypeService = resourceTypeService ?? throw new ArgumentNullException(nameof(resourceTypeService));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _expectedResources = new Lazy<IEnumerable<ExpectedResource>>(LoadExpectedResources);
        }

        public IEnumerable<ExpectedResource> GetExpectedResources()
        {
            return ExpectedResources;
        }

        private IEnumerable<ExpectedResource> LoadExpectedResources()
        {
            using var sr = new StreamReader("expectedresources.json");
            var content = sr.ReadToEnd();

            var result = JsonConvert.DeserializeObject<IEnumerable<IDictionary<string, string>>>(content);

            var expectedResources = new List<ExpectedResource>();
            foreach (var item in result)
            {
                var resourceType = _resourceTypeService.GetResourceType(item["ResourceType"]);
                var resourceId = item["ResourceId"];

                if (resourceType.Name == "SystemUser" && resourceId == "[[ContextUser]]")
                {
                    var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
                    resourceId = userName;
                }

                var expectedResource = new ExpectedResource()
                {
                    ResourceDescription = new ResourceDescription(resourceType, resourceId),
                    Required = bool.Parse(item["Required"])
                };
            
                expectedResources.Add(expectedResource);
            }

            return expectedResources;
        }
    }
}