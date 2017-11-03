using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DI_Mvc_Autofac.Infrastructure.Interfaces;
using DI_Mvc_Autofac.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Owin;

[assembly: OwinStartupAttribute(typeof(DI_Mvc_Autofac.Startup))]
namespace DI_Mvc_Autofac
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            SetupIoC(app);
            ConfigureAuth(app);
        }

        private void SetupIoC(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            //
            // Register Dependencies
            //

            builder.RegisterType<DebugLogger>().AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();

            builder.Register<IAuthenticationManager>(c=>HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerRequest();
            //
            // Register Controllers
            //
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof (MvcApplication).Assembly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //
            // Register OWIN
            //
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();


        }
    }
}
