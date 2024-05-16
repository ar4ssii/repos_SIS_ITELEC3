using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SIS_ITELEC3.Startup))]
namespace SIS_ITELEC3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
