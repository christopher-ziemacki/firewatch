using System;

namespace Firewatch.App.Models
{
    public class Instance
    {
        public Guid Id { get; set; }
        public string UniqueName { get; set; }
        
        public Uri Url { get; set; }
        public string Version { get; set; }

        public bool DoesCurrentUserHaveAccess { get; set; }
        public bool DoesTeamAdministratorHaveAccess { get; set; }
    }
}
