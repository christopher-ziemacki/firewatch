using System;

namespace Firewatch.App.ViewModels
{
    public class InstanceTableRowData
    {
        public Guid Id { get; set; }
        public string UniqueName { get; set; }
        
        public Uri Url { get; set; }
        public string Version { get; set; }

        public bool DoesCurrentUserHaveAccess { get; set; }
    }
}
