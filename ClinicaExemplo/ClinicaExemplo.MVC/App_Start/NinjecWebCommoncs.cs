using System;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using System.Web;
using ClinicaExemplo.Application;
using ClinicaExemplo.Application.Interface;
using ClinicaExemplo.Domain.Services;
using ClinicaExemplo.Domain.Interfaces;
using ClinicaExemplo.Domain.Interfaces.Services;
using ClinicaExemplo.Infra.Data.Repositories;
using ClinicaExemplo.Infra.Data;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ClinicaExemplo.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ClinicaExemplo.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace ClinicaExemplo.MVC.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }

        }
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IAgendamentoAppService>().To<AgendamentoAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IAgendamentoService>().To<AgendamentoService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IAgendamentoRepository>().To<AgendamentoRepository>();


        }
    }
}
