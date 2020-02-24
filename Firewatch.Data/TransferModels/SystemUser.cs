using System;

namespace Firewatch.Data.TransferModels
{
    internal class SystemUser
    {
        public Guid Id { get; set; }

        public int AccessMode { get; set; }
        public string DomainName { get; set; }
        public bool IsDisabled { get; set; }
    }
}
