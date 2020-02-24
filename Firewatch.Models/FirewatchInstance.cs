using System;
using System.Collections.Generic;
using System.Text;

namespace Firewatch.Models
{
    public class FirewatchInstance
    {
        public Instance Instance { get; set; }

        public SystemUser ContextUser { get; set; }
        public SystemUser TeamAdminUser { get; set; }

        public bool DoesContextUserHaveAccess => ContextUser != null && ContextUser.IsDisabled == false;
        public bool DoesTeamAdminUserHaveAccess => TeamAdminUser != null && TeamAdminUser.IsDisabled == false;

        public bool RequiresAttention
        {
            get { return DoesTeamAdminUserHaveAccess == false; }
        }
    }
}
