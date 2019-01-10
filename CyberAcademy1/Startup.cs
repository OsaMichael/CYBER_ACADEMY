using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CyberAcademy1.Startup))]
namespace CyberAcademy1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
