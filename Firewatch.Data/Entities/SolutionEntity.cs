using System;

namespace Firewatch.Data.Entities
{
    internal class SolutionEntity : Entity
    {
        public Guid Id { get; set; }

        public string UniqueName { get; set; }
    }
}
