using Abp.Application.Services;
using BoilerPlate.MultiTenancy.Dto;

namespace BoilerPlate.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

