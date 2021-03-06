﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Logging;

namespace SMSWallBackend.Hubs
{
    public class ConfigHub : Hub
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public async Task InitializeSession(string config)
        {
            string configId = RandomString(32);
            try
            {
                File.WriteAllText(configId, config);
            }catch(Exception e)
            {
                File.WriteAllText("log", e.Message);
            }
            await Clients.Caller.SendAsync("GetConfigId", $"{configId}");
            _ = CleanUp(configId);
        }
        public async Task GetConfig(string configId)
        {
            await Clients.Caller.SendAsync("GetConfig", File.ReadAllText(configId));
        }

        public async Task CleanUp(string configId)
        {
            await Task.Delay(60000);
            try
            {
                File.Delete(configId);
            }catch (Exception)
            {

            }
        }
    }
}
