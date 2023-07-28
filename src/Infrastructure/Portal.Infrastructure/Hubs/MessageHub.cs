using Microsoft.AspNetCore.SignalR;

namespace Portal.Infrastructure.Hubs
{
    public class MessageHub: Hub
    {
        public async Task SendMessageAsync()
        {
          
            //await Clients.All.SendAsync("receiveMessage", "hello");
        }
    }
}
