using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MYIMBD.Startup))]
namespace MYIMBD
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
