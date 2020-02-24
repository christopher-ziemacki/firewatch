using System;

namespace Firewatch.Data.TransferModels
{
    internal class Instance
    {
        public Guid Id { get; set; }

        public string UniqueName { get; set; }
        public string UrlName { get; set; }

        public string Url { get; set; }
        public string Version { get; set; }
    }
}
