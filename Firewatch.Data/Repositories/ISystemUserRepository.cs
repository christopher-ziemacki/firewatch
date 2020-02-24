using System.Threading.Tasks;
using Firewatch.Models;

namespace Firewatch.Data.Repositories
{
    public interface ISystemUserRepository
    {
        Task<SystemUser> GetSystemUser(string instanceUrlName, string systemUserDomainName);
    }
}
