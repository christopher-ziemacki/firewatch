using System;

namespace Firewatch.Data.Entities
{
    internal class InstanceEntity
    {
        public Guid Id { get; set; }

        public string UniqueName { get; set; }
        public string UrlName { get; set; }

        public string Url { get; set; }
        public string Version { get; set; }
    }
}
