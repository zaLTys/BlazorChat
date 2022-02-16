using BlazorChat.Shared;
using Microsoft.AspNetCore.SignalR;

namespace BlazorChat.Server.Hubs
{
    //[Authorize]
    public class ChatHub : Hub
    {
        private static Dictionary<string, string> Users = new();

        public override async Task OnConnectedAsync()
        {
            var username = Context.GetHttpContext().Request.Query["username"];
            Users.Add(Context.ConnectionId, username);
            await SendMessage(string.Empty, $"{username} connected");
            await Clients.Caller.SendAsync("FocusOnInput");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            string username = Users.FirstOrDefault(x => x.Key == Context.ConnectionId).Value;
            await SendMessage(string.Empty, $"{username} disconnected");
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync(Constants.ReceiveMessage, user, message);
        }
    }
}
