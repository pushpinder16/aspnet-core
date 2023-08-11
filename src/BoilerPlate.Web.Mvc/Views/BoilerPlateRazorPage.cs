using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace BoilerPlate.Web.Views
{
    public abstract class BoilerPlateRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected BoilerPlateRazorPage()
        {
            LocalizationSourceName = BoilerPlateConsts.LocalizationSourceName;
        }
    }
}
