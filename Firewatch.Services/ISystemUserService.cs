using System.Threading.Tasks;

namespace Firewatch.Services
{
    public interface ISystemUserService
    {
        Task<bool> DoesUserHaveAccess(string instanceUrlName, string systemUserDomainName);
    }
}
