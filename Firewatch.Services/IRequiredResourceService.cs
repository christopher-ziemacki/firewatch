using System.Collections.Generic;
using Firewatch.Models.Resources;

namespace Firewatch.Services
{
    public interface IRequiredResourceService
    {
        IEnumerable<RequiredResource> GetRequiredResources();
    }
}
