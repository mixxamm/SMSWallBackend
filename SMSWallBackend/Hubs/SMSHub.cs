using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSWallBackend.Hubs
{
    public class SMSHub : Hub
    {
        public async Task SendSMS(string sms, string groupName)
        {
            await Clients.Group(groupName).SendAsync("ReceiveSMS", new SMS() { Date = DateTime.Now, Message = sms});
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
