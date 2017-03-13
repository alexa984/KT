[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(IS.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(IS.Web.App_Start.NinjectWebCommon), "Stop")]

namespace IS.Web.App_Start
{
    using System;
    using System.Web;
    using System.Data.Entity;

    using Ninject;
    using Ninject.Web.Common;
    using IS.Data;
    using IS.Data.Models;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Data.Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using System.Net;
    using Microsoft.Owin.Security;
    using Models;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
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

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<IdentityDbContext>();
            kernel.Bind<IDeletableEntity>().To<DeletableEntity>();
            kernel.Bind<IUserStore<Business>>().To<UserStore<Business>>();
            kernel.Bind<IUserStore<ISUser>>().To<UserStore<ISUser>>();
            kernel.Bind<IAuthenticationManager>().ToMethod(
    c =>
        HttpContext.Current.GetOwinContext().Authentication).InRequestScope();
            kernel.Bind<IISData>().To<ISData>();
            kernel.Bind<IRepository<ForumPost>>().To<IDeletableEntityRepository<ForumPost>>();
            kernel.Bind(typeof(IDeletableEntityRepository<>)).To(typeof(DeletableEntityRepository<>));
            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
        }
    }
}
