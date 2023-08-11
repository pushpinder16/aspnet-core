using Abp.Application.Services;
using BoilerPlate.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace BoilerPlate.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
