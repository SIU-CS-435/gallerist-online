using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace TeamJAMiN
{
    public partial class Startup
    {
        public void ConfigureSignalR(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}
