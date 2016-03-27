using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamJAMiN.Startup))]
namespace TeamJAMiN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureSignalR(app);
        }
    }
}
