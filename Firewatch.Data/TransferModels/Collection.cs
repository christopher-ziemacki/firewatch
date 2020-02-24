using System.Collections.Generic;

namespace Firewatch.Data.TransferModels
{
    internal class Collection<T>
    {
        public IEnumerable<T> Value { get; set; }
    }
}
