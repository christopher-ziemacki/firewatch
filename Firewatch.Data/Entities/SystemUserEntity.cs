using System;

namespace Firewatch.Data.Entities
{
    internal class SystemUserEntity : Entity
    {
        public Guid Id { get; set; }

        public int AccessMode { get; set; }
        public string DomainName { get; set; }
        public bool IsDisabled { get; set; }
    }
}
