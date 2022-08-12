using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRServerExample.Hubs
{
    public class MyHub : Hub
    {
        static List<string> clients = new List<string>();
        // client lardaki receiceMessage fonksiyonlarini tetikleyen method
        //public async Task SendMessageAsync(string message)
        //{
        //    await Clients.All.SendAsync("receiveMessage", message);
        //}

        // Yukaridaki metodu IHubContext ten faydalanarak Business larimizi yonettigimiz siniflarda kullanabiliyoruz. Bu ornek proje icin bizim MyBusiness classina bu metodu tasidik.

        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
            await Clients.All.SendAsync("userJoined", Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
            await Clients.All.SendAsync("userLeft", Context.ConnectionId);
        }
    }
}