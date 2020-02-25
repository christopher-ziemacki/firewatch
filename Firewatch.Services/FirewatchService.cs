using Firewatch.Models;
using Firewatch.Services.ResourceProviders;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firewatch.Data.Repositories;
using Firewatch.Models.Resources;

namespace Firewatch.Services
{
    public class FirewatchService : IFirewatchService
    {
        private readonly IResourceProviderFactory _resourceProviderFactory;
        private readonly IInstanceRepository _instanceRepository;

        private readonly ResourceDescription[] _resourceDescriptions;

        public FirewatchService(IResourceProviderFactory resourceProviderFactory,
            IInstanceRepository instanceRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _resourceProviderFactory = resourceProviderFactory ??
                                       throw new ArgumentNullException(nameof(resourceProviderFactory));
            
            _instanceRepository = instanceRepository ?? throw new ArgumentNullException(nameof(instanceRepository));

            if (httpContextAccessor == null)
            {
                throw new ArgumentNullException(nameof(httpContextAccessor));
            }

            _resourceDescriptions = new[]
            {
                new ResourceDescription(ResourceType.SystemUser, "teklaad\\crmteamadmin"),
                new ResourceDescription(ResourceType.SystemUser, httpContextAccessor.HttpContext.User.Identity.Name),

                new ResourceDescription(ResourceType.Solution, "DataModelBase"),
                new ResourceDescription(ResourceType.Solution, "TrimbleSolutionsCore"),
            };
        }

        public async Task<IEnumerable<FirewatchInstance>> GetFirewatchInstances()
        {
            var instances = await _instanceRepository.GetInstances();

            var tasks = instances.Select(instance => GetResources(instance, _resourceDescriptions)).ToList();

            var resourceCollections = await Task.WhenAll(tasks);
            return null;
        }

        private async Task<IEnumerable<Resource>> GetResources(Instance instance,
            IEnumerable<ResourceDescription> resourceDescriptions)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            var tasks = resourceDescriptions.Select(resourceDescription => GetResource(instance, resourceDescription))
                .ToList();

            return await Task.WhenAll(tasks);
        }

        private async Task<Resource> GetResource(Instance instance, ResourceDescription resourceDescription)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            var resourceRequest = new ResourceRequest(instance.Id, instance.UrlName, resourceDescription);
            var resourceProvider =
                _resourceProviderFactory.CreateResourceProvider(resourceRequest.ResourceDescription.ResourceType);

            var resource = await resourceProvider.GetResource(resourceRequest);

            return resource;
        }
    }
}