using System;
using Newtonsoft.Json;

namespace Firewatch.Models.Resources
{
    public class ExternalServiceResource : Resource
    {
        public static readonly ResourceType ExternalServiceResourceType = new ResourceType("ExternalService",
            "{0}/api/data/v9.0/ts_externalservices?$filter=ts_externalserviceid eq {1}",
            "Firewatch.Models.Resources.ExternalServiceResource");

        [JsonProperty("ts_externalserviceid")]
        public Guid ExternalServiceId { get; set; }

        [JsonProperty("ts_externalserviceuri")]
        public Uri ExternalServiceUri { get; set; }

        public ExternalServiceResource()
        {
            ResourceType = ExternalServiceResourceType;
        }
    }
}
