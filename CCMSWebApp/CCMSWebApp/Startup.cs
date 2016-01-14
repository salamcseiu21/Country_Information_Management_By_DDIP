using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CCMSWebApp.Startup))]
namespace CCMSWebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
