using System;

namespace Firewatch.Models
{
    public class Instance
    {
        public Guid Id { get; set; }
        public string UniqueName { get; set; }
        public string UrlName { get; set; }

        public Uri Url { get; set; }
        public string Version { get; set; }
    }
}
