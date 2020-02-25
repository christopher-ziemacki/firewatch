using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Firewatch.Data.Entities;
using Firewatch.Models.Resources;

namespace Firewatch.Data.Repositories
{
    public class ResourceRepository : IResourceRepositoryEx
    {
        private readonly HttpClient _httpClient;

        public ResourceRepository(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<T> GetResource<T>(ResourceRequest resourceRequest) where T : Resource, new()
        {
            var resourceType = resourceRequest.ResourceDescription.ResourceType;

            var uri = new Uri(
                string.Format(resourceType.UriTemplate, resourceRequest.InstanceUrlName,
                    resourceRequest.ResourceDescription.ResourceName), UriKind.Relative);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return default;
            }

            var content = await response.Content.ReadAsAsync<EntityCollection<T>>();
            var value = content.Value?.SingleOrDefault();

            return value;
        }

        public async Task<Resource> GetResource(ResourceRequest resourceRequest)
        {
            var resourceType = resourceRequest.ResourceDescription.ResourceType;

            if (resourceType.Name == "SystemUser")
            {
                return await GetResource<SystemUserResource>(resourceRequest);
            }

            return null;
        }
    }
}