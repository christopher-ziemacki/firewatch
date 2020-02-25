using System;

namespace Firewatch.Models.Resources
{
    public readonly struct ResourceType
    {
        public string Name { get; }
        public string UriTemplate { get; }
        public Type ModelType { get; }

        public ResourceType(string name, string uriTemplate, string modelTypeName)
        {
            Name = name;
            UriTemplate = uriTemplate;

            var asm = typeof(Resource).Assembly;
            ModelType = asm.GetType("Firewatch.Models.Resources.SystemUserResource");
        }

        public override bool Equals(object obj) =>
            obj is ResourceType resourceType && this == resourceType;

        public override int GetHashCode() => Name.GetHashCode() ^ UriTemplate.GetHashCode() ^ ModelType.GetHashCode();

        public static bool operator ==(ResourceType rt1, ResourceType rt2) =>
            rt1.Name == rt2.Name && rt1.UriTemplate == rt2.UriTemplate && rt1.ModelType == rt2.ModelType;

        public static bool operator !=(ResourceType rt1, ResourceType rt2) =>
            rt1.Name != rt2.Name || rt1.UriTemplate != rt2.UriTemplate || rt1.ModelType != rt2.ModelType;
    }
}