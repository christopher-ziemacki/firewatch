namespace Firewatch.Models.Resources
{
    public class SdkMessageProcessingStepSecureConfigResource : Resource
    {
        public static readonly ResourceType SdkMessageProcessingStepSecureConfigResourceType = new ResourceType("SdkMessageProcessingStepSecureConfig",
            "{0}/api/data/v9.0/sdkmessageprocessingstepsecureconfigs",
            "Firewatch.Models.Resources.SdkMessageProcessingStepSecureConfigResource");

        public SdkMessageProcessingStepSecureConfigResource()
        {
            ResourceType = SdkMessageProcessingStepSecureConfigResourceType;
        }
    }
}
