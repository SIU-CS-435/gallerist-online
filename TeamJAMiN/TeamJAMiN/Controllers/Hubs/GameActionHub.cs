using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TeamJAMiN.Controllers.Hubs
{
    public class GameActionHub : Hub
    {
        public void Update(string action)
        {
            Clients.All.serverResponse(action);
        }
    }
}