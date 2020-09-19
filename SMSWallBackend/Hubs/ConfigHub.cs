using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSWallBackend.Hubs
{
    public class ConfigHub : Hub
    {
        private Dictionary<string, string> configs = new Dictionary<string, string>();
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public async Task InitializeSession(string config)
        {
            string configId = RandomString(8);
            configs.Add(configId, config);
            await Clients.Caller.SendAsync("GetConfigId", configId);
        }
        public async Task GetConfig(string configId)
        {
            configs.TryGetValue(configId, out string config);
            await Clients.Caller.SendAsync("GetConfig", config);
        }
    }
}
