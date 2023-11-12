using Microsoft.AspNetCore.SignalR;

namespace HiLoGuessing.WebAPI.SignalR.Hubs
{
    public class PlayerHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }

}
