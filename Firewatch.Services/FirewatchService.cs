using Firewatch.Models;
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
        private readonly IInstanceRepository _instanceRepository;
        private readonly IResourceRepository _resourceRepository;
        private readonly IExpectedResourceService _requiredResourceService;

        public FirewatchService(
            IInstanceRepository instanceRepository, IResourceRepository resourceRepository,
            IExpectedResourceService requiredResourceService,
            IHttpContextAccessor httpContextAccessor)
        {
            _instanceRepository = instanceRepository ?? throw new ArgumentNullException(nameof(instanceRepository));
            _resourceRepository = resourceRepository ?? throw new ArgumentNullException(nameof(resourceRepository));
            _requiredResourceService = requiredResourceService ??
                                       throw new ArgumentNullException(nameof(requiredResourceService));

            if (httpContextAccessor == null)
            {
                throw new ArgumentNullException(nameof(httpContextAccessor));
            }
        }

        public async Task<IEnumerable<FirewatchInstance>> GetFirewatchInstances()
        {
            var requiredResources = _requiredResourceService.GetExpectedResources().ToArray();
            var resourceDescriptions = requiredResources.Select(rr => rr.ResourceDescription);

            var instances = await _instanceRepository.GetInstances();

            var tasks = instances.Select(async instance => new FirewatchInstance()
                    {Instance = instance, ExpectedResources = requiredResources, Resources = await GetResources(instance, resourceDescriptions)})
                .ToList();

            var firewatchInstances = await Task.WhenAll(tasks);
            
            return firewatchInstances;
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
            return await Task.WhenAll(tasks).ContinueWith(t => t.Result.Where(r => r != null).ToList());
        }

        private async Task<Resource> GetResource(Instance instance, ResourceDescription resourceDescription)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            var resourceRequest = new ResourceRequest(instance.Id, instance.UrlName, resourceDescription);

            var resource = await _resourceRepository.GetResource(resourceRequest);
            return resource;
        }
    }
}