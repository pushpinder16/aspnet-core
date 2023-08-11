using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BoilerPlate.Roles.Dto;
using BoilerPlate.Users.Dto;
using System.Threading.Tasks;

namespace BoilerPlate.Users
{
    public interface IUserService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task DeActivate(EntityDto<long> user);
        Task Activate(EntityDto<long> user);
        Task<ListResultDto<RoleDto>> GetRoles();
        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
