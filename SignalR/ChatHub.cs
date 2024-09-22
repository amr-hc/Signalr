using Microsoft.AspNetCore.SignalR;

namespace SignalR
{
    public class ChatHub : Hub
    {
        // You can define methods that clients can call
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);

        }
    }
}