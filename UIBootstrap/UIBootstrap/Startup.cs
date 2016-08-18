using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UIBootstrap.Startup))]
namespace UIBootstrap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
