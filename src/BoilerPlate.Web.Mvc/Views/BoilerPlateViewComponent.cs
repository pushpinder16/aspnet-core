using Abp.AspNetCore.Mvc.ViewComponents;

namespace BoilerPlate.Web.Views
{
    public abstract class BoilerPlateViewComponent : AbpViewComponent
    {
        protected BoilerPlateViewComponent()
        {
            LocalizationSourceName = BoilerPlateConsts.LocalizationSourceName;
        }
    }
}
