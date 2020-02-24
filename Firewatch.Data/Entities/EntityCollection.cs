using System.Collections.Generic;

namespace Firewatch.Data.Entities
{
    internal class EntityCollection<T>
    {
        public IEnumerable<T> Value { get; set; }
    }
}
