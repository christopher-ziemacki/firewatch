using System.Collections.Generic;
using Firewatch.Models.Resources;

namespace Firewatch.Models
{
    public class FirewatchInstance
    {
        public Instance Instance { get; set; }

        public IEnumerable<Resource> Resources { get; set; }
    }
}
