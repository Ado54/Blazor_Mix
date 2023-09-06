using Microsoft.AspNetCore.SignalR;
using System.Net.Mail;

namespace Project_with_Login.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}