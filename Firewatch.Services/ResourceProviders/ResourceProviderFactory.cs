using System;
using System.Collections.Generic;
using Firewatch.Models.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace Firewatch.Services.ResourceProviders
{
    public class ResourceProviderFactory : IResourceProviderFactory
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly Dictionary<ResourceType, Type> _resourceTypeDictionary = new Dictionary<ResourceType, Type>()
        {
            {new ResourceType("Solution", string.Empty, "Firewatch.Models.Resources.SystemUserResource"), typeof(ISolutionProvider) },
            {new ResourceType("SystemUser", string.Empty, ""), typeof(ISystemUserProvider) }
        };

        public ResourceProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public IResourceProvider CreateResourceProvider(ResourceType resourceType)
        {
            var type = _resourceTypeDictionary[resourceType];
            var resourceProvider = (IResourceProvider)_serviceProvider.GetService(type);

            return resourceProvider;
        }

        public T CreateResourceProvider<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}