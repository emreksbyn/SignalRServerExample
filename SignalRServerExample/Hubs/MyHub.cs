using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRServerExample.Hubs
{
    // IMessageClient interfaceni MyHub sinifinda kullanmak icin generic olarak Hub classina bagladik.
    public class MyHub : Hub<IMessageClient>
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
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userJoined", Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserJoined(Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            clients.Remove(Context.ConnectionId);
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userLeft", Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserLeft(Context.ConnectionId);
        }
    }
}