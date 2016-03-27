using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TeamJAMiN.Controllers.ActionHub
{
    public class GameActionHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}