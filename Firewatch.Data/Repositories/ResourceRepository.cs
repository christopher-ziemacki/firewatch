using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Firewatch.Data.Entities;
using Firewatch.Models.Resources;
using Microsoft.AspNetCore.Http;

namespace Firewatch.Data.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ResourceRepository(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<Resource> GetResource(ResourceRequest resourceRequest)
        {
            var resourceType = resourceRequest.ResourceDescription.ResourceType;

            var uriStr = string.Format(resourceType.UriTemplate, resourceRequest.InstanceUrlName,
                resourceRequest.ResourceDescription.ResourceId, string.Empty);

            if (resourceType.Properties != null && resourceType.Properties.Any())
            {
                var selectedProperties =
                    string.Join(",", resourceType.Properties.Select(p => p.JsonProperty.ToLower()));
                uriStr = uriStr.Contains("?")
                    ? $"{uriStr}&$select={selectedProperties}"
                    : $"{uriStr}?$select={selectedProperties}";
            }

            var uri = new Uri(uriStr, UriKind.Relative);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return default;
            }

            var content = await response.Content.ReadAsAsync<EntityCollection<IDictionary<string, string>>>();

            var entityProperties = content?.Value?.SingleOrDefault();
            if (entityProperties == null)
            {
                return null;
            }

            var resource = new Resource
            {
                InstanceId = resourceRequest.InstanceId, ResourceDescription = resourceRequest.ResourceDescription
            };

            if (resourceType.Properties == null)
            {
                return resource;
            }

            foreach (var property in resourceType.Properties)
            {
                var value = entityProperties[property.JsonProperty.ToLower()];
                resource.Values[property.Name] = new ResourceValue(property, value);
            }

            if (resourceType.Name == "SystemUser" && resource.Values["DomainName"].Value ==
                _httpContextAccessor.HttpContext.User.Identity.Name)
            {
                resource.Values["IsContextUser"] = new ResourceValue(null, "true");
            }

            return resource;
        }
    }
}