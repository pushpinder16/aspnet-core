using Abp.Application.Services;
using BoilerPlate.Sessions.Dto;
using System.Threading.Tasks;

namespace BoilerPlate.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
