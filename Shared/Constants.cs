using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorChat.Shared
{
    public static class Constants
    {
        public const string ReceiveMessage = "ReceiveMessage";
        public const string ChatHubBase = "/chathub";
        public const string ChatHubWithUsername = $"{ChatHubBase}?username=";

        public const string HubMethodSendMessage = "SendMessage";
    }
}
