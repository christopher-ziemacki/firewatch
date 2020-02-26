using System.Collections.Generic;
using Firewatch.Models.Resources;

namespace Firewatch.Services
{
    public interface IExpectedResourceService
    {
        IEnumerable<ExpectedResource> GetExpectedResources();
    }
}
