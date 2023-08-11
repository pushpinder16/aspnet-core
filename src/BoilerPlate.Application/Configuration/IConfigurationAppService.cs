using BoilerPlate.Configuration.Dto;
using System.Threading.Tasks;

namespace BoilerPlate.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
