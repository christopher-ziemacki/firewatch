using System;
using System.Threading.Tasks;
using AutoMapper;
using Firewatch.Data.Repositories;
using Firewatch.Models;
using Firewatch.Models.Resources;

namespace Firewatch.Services.ResourceProviders
{
    public class AbstractProvider<T, TU> : IResourceProvider where T : IResourceRepository<TU> where TU : Resource
    {
        private readonly T _repository;
        private readonly IMapper _mapper;

        public AbstractProvider(T repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Resource> GetResource(ResourceRequest resourceRequest)
        {

            var resource = await _repository.GetResource(resourceRequest.InstanceUrlName, resourceRequest.ResourceDescription.ResourceName);

            if (resource == null)
            {
                return null;
            }

            resource.InstanceId = resourceRequest.InstanceId;
            resource.ResourceType = resourceRequest.ResourceDescription.ResourceType;

            return resource;
        }
    }
}
