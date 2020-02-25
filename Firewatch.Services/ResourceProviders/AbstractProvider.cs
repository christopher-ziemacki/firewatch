using System;
using System.Threading.Tasks;
using Firewatch.Data.Repositories;
using Firewatch.Models.Resources;

namespace Firewatch.Services.ResourceProviders
{
    public class AbstractProvider<T, TU> : IResourceProvider where T : IResourceRepository<TU> where TU : Resource
    {
        private readonly T _repository;

        public AbstractProvider(T repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
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
