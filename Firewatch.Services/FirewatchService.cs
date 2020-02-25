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
        private readonly IResourceRepositoryEx _resourceRepositoryEx;

        private readonly ResourceDescription[] _resourceDescriptions;

        public FirewatchService(IResourceProviderFactory resourceProviderFactory,
            IInstanceRepository instanceRepository, IResourceRepositoryEx resourceRepositoryEx,
            IHttpContextAccessor httpContextAccessor)
        {
            _resourceProviderFactory = resourceProviderFactory ??
                                       throw new ArgumentNullException(nameof(resourceProviderFactory));

            _instanceRepository = instanceRepository ?? throw new ArgumentNullException(nameof(instanceRepository));
            _resourceRepositoryEx =
                resourceRepositoryEx ?? throw new ArgumentNullException(nameof(resourceRepositoryEx));

            if (httpContextAccessor == null)
            {
                throw new ArgumentNullException(nameof(httpContextAccessor));
            }

            _resourceDescriptions = new[]
            {
                new ResourceDescription(new ResourceType("SystemUser", string.Empty, "Firewatch.Models.Resources.SystemUserResource"), "teklaad\\crmteamadmin"),
                new ResourceDescription(new ResourceType("SystemUser", string.Empty, "Firewatch.Models.Resources.SystemUserResource"),
                    httpContextAccessor.HttpContext.User.Identity.Name),

                new ResourceDescription(new ResourceType("Solution", string.Empty, string.Empty), "DataModelBase"),
                new ResourceDescription(new ResourceType("Solution", string.Empty, string.Empty), "TrimbleSolutionsCore"),
            };
        }

        public async Task<IEnumerable<FirewatchInstance>> GetFirewatchInstances()
        {
            var resource = await _resourceRepositoryEx.GetResource(new ResourceRequest(Guid.Parse("6f9f58c4-dbda-e911-9120-4c5262036875"),
                "PR",
                new ResourceDescription(
                    new ResourceType("SystemUser", "{0}/api/data/v9.0/systemusers?$filter=domainname eq '{1}'", "Firewatch.Models.Resources.SystemUserResource"),
                    "teklaad\\crmteamadmin")));

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
            return await Task.WhenAll(tasks).ContinueWith(t => t.Result.Where(r => r != null).ToList());
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