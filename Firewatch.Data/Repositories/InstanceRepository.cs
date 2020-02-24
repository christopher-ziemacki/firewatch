using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Firewatch.Data.Entities;
using Firewatch.Models;

namespace Firewatch.Data.Repositories
{
    public class InstanceRepository : IInstanceRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public InstanceRepository(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Instance>> GetInstances()
        {
            var uri = new Uri("api/discovery/v9.0/Instances", UriKind.Relative);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return default;
            }

            var instanceEntityCollection =
                await response.Content.ReadAsAsync<EntityCollection<InstanceEntity>>();

            var instances = instanceEntityCollection?.Value == null
                ? Enumerable.Empty<Instance>()
                : _mapper.Map<IEnumerable<Instance>>(instanceEntityCollection.Value);

            return instances;
        }
    }
}