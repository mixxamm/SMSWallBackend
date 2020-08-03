using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSWallBackend.Hubs
{
    public class SMSHub : Hub
    {
        public async Task SendSMS(string sms)
        {
            await Clients.Others.SendAsync("ReceiveSMS", new SMS() { Date = DateTime.Now, Message = sms});
        }
    }
}
