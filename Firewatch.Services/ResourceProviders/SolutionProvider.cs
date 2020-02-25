using Firewatch.Data.Repositories;
using Firewatch.Models.Resources;

namespace Firewatch.Services.ResourceProviders
{
    public class SolutionProvider : AbstractProvider<ISolutionRepository, SolutionResource>, ISolutionProvider
    {
        public SolutionProvider(ISolutionRepository solutionRepository) : base(solutionRepository)
        {
            
        }
    }
}
