using System;
using System.Threading.Tasks;
using Firewatch.Data.Repositories;
using Firewatch.Models.Resources;

namespace Firewatch.Services.ResourceProviders
{
    public class ResourceProvider : IResourceProvider
    {
        private readonly IResourceRepository _repository;

        public ResourceProvider(IResourceRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Resource> GetResource(ResourceRequest resourceRequest)
        {

            var resource = await _repository.GetResource(resourceRequest);

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
