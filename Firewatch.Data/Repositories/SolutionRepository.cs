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
    public class SolutionRepository : ISolutionRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public SolutionRepository(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SolutionResource> GetResource(string instanceUrlName, string solutionUniqueName)
        {
            if (instanceUrlName == null)
            {
                throw new ArgumentNullException(nameof(instanceUrlName));
            }

            if (solutionUniqueName == null)
            {
                throw new ArgumentNullException(nameof(solutionUniqueName));
            }

            var uri = new Uri($"{instanceUrlName}/api/data/v9.0/solutions?$filter=uniquename eq '{solutionUniqueName}'",
                UriKind.Relative);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return default;
            }

            var solutionEntityCollection = await response.Content.ReadAsAsync<EntityCollection<SolutionEntity>>();
            var solutionEntity = solutionEntityCollection?.Value?.SingleOrDefault();

            var solution = solutionEntity == null ? null : _mapper.Map<SolutionResource>(solutionEntity);

            return solution;
        }
    }
}