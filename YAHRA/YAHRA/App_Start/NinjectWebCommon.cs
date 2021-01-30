[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(YAHRA.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(YAHRA.App_Start.NinjectWebCommon), "Stop")]

namespace YAHRA.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using AutoMapper;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using YAHRA.API.Services;
    using YAHRA.API.Services.Interfaces;
    using YAHRA.Mappers;
    using YAHRA.Repositories;
    using YAHRA.Repositories.Interfaces;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new AutoMapperModule());
            var mapperConfiguration = new MapperConfiguration(
                cfg => { 
                    cfg.AddProfile<EmployeeMapperProfile>();
                });
            kernel.Bind<IMapper>().ToConstructor(c => new Mapper(mapperConfiguration)).InSingletonScope();

            var mapper = kernel.Get<IMapper>();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEmployeeRepository>().To<EmployeeRepository>();
            kernel.Bind<IEmployeeService>().To<EmployeeService>();
        }
    }
}