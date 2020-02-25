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
        private readonly IInstanceRepository _instanceRepository;
        private readonly IResourceProvider _resourceProvider;

        private readonly ResourceDescription[] _resourceDescriptions;

        public FirewatchService(
            IInstanceRepository instanceRepository, IResourceProvider resourceProvider,
            IHttpContextAccessor httpContextAccessor)
        {
            _instanceRepository = instanceRepository ?? throw new ArgumentNullException(nameof(instanceRepository));
            _resourceProvider = resourceProvider ?? throw new ArgumentNullException(nameof(resourceProvider));

            if (httpContextAccessor == null)
            {
                throw new ArgumentNullException(nameof(httpContextAccessor));
            }

            _resourceDescriptions = new[]
            {
                new ResourceDescription(SystemUserResource.SystemUserResourceType, "teklaad\\crmteamadmin"),
                new ResourceDescription(SystemUserResource.SystemUserResourceType,
                    httpContextAccessor.HttpContext.User.Identity.Name),

                new ResourceDescription(SolutionResource.SolutionResourceType, "DataModelBase"),
                new ResourceDescription(SolutionResource.SolutionResourceType, "TrimbleSolutionsCore"),

                new ResourceDescription(ExternalServiceResource.ExternalServiceResourceType, "6e0d59cf-6a5b-e911-9105-4c5262036875"),

                new ResourceDescription(SdkMessageProcessingStepSecureConfigResource.SdkMessageProcessingStepSecureConfigResourceType, string.Empty),
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
            return await Task.WhenAll(tasks).ContinueWith(t => t.Result.Where(r => r != null).ToList());
        }

        private async Task<Resource> GetResource(Instance instance, ResourceDescription resourceDescription)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            var resourceRequest = new ResourceRequest(instance.Id, instance.UrlName, resourceDescription);
         
            var resource = await _resourceProvider.GetResource(resourceRequest);
            return resource;
        }
    }
}