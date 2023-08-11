using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BoilerPlate.EntityFrameworkCore;
using BoilerPlate.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace BoilerPlate.Web.Tests
{
    [DependsOn(
        typeof(BoilerPlateWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BoilerPlateWebTestModule : AbpModule
    {
        public BoilerPlateWebTestModule(BoilerPlateEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        }

        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BoilerPlateWebTestModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BoilerPlateWebMvcModule).Assembly);
        }
    }
}