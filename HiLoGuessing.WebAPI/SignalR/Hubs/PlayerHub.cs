using HiloGuessing.Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace HiLoGuessing.WebAPI.SignalR.Hubs
{
    public class PlayerHub : Hub
    {
        public string GroupName { get; set; }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task PlayerJoined(HiLoGuess hiLoGuess)
        {
            await Clients.All.SendAsync("PlayerJoined", hiLoGuess);
        }

        public async Task PlayerGuessed(HiLoGuess hiLoGuess)
        {
            await Clients.All.SendAsync("PlayerGuessed", hiLoGuess);
        }

        public async Task SentGuess(HiLoGuess hiLoGuess)
        {
            await Clients.All.SendAsync("SentGuess", hiLoGuess);
        }

        public async Task SendMysteryNumber(string hiLoGuessId, string mysteryNumber)
        {
            await Clients.All.SendAsync("ReceiveMysteryNumber", hiLoGuessId, mysteryNumber);
        }

        public async Task JoinGroup(string groupName)
        {
            GroupName = groupName;
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("PlayerJoined", $"{Context.ConnectionId} joined {groupName}");
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            // Access the group name associated with the connection
            var groupName = Context.GetHttpContext().Request.Query["group"].ToString();

            // Remove the disconnected player from the group
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await base.OnDisconnectedAsync(exception);
        }

    }

}
