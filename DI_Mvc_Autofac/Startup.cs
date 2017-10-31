using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DI_Mvc_Autofac.Startup))]
namespace DI_Mvc_Autofac
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
