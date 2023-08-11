using Abp.Modules;
using Abp.Reflection.Extensions;
using BoilerPlate.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace BoilerPlate.Web.Startup
{
    [DependsOn(typeof(BoilerPlateWebCoreModule))]
    public class BoilerPlateWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BoilerPlateWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<BoilerPlateNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BoilerPlateWebMvcModule).GetAssembly());
        }
    }
}
