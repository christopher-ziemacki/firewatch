using System.Threading.Tasks;
using Firewatch.Models;

namespace Firewatch.Services
{
    public interface ISystemUserService
    {
        Task<SystemUser> GetSystemUser(string instanceUrlName, string systemUserDomainName);
    }
}
