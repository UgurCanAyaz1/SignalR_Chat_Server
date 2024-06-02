using Microsoft.AspNetCore.SignalR;

namespace SignalR_Chat_Server.SignalR
{
    public class MessageHub : Hub
    {   
        // Function to be executed upon triggering sendMessage function at Client Side
        public async Task SendMessage(string user, string message)
        {
            //  Send signal to client regarding calling the ReceiveMessage function
            await Clients.All.SendAsync("ReceiveMessage", user, message); 
        }

    }
}
