using Abp.Authorization;
using Abp.Runtime.Session;
using BoilerPlate.Configuration.Dto;
using System.Threading.Tasks;

namespace BoilerPlate.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BoilerPlateAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
