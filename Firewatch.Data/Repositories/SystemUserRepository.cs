using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Firewatch.Data.Entities;
using Firewatch.Models;
using Firewatch.Models.Resources;

namespace Firewatch.Data.Repositories
{
    public class SystemUserRepository : ISystemUserRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public SystemUserRepository(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SystemUserResource> GetResource(string instanceUrlName, string resourceName)
        {
            if (instanceUrlName == null)
            {
                throw new ArgumentNullException(nameof(instanceUrlName));
            }

            if (resourceName == null)
            {
                throw new ArgumentNullException(nameof(resourceName));
            }

            var uri = new Uri(
                $"{instanceUrlName}/api/data/v9.0/systemusers?$filter=domainname eq '{resourceName}'",
                UriKind.Relative);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return default;
            }

            var systemUserEntityCollection = await response.Content.ReadAsAsync<EntityCollection<SystemUserEntity>>();
            var systemUserEntity = systemUserEntityCollection?.Value?.SingleOrDefault();

            var systemUserResource = systemUserEntity == null ? null : _mapper.Map<SystemUserResource>(systemUserEntity);

            return systemUserResource;
        }
    }
}
