using Microsoft.AspNetCore.SignalR;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServerExample.Hubs
{
    public class MessageHub : Hub
    {
        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        //public async Task SendMessageAsync(string message, string groupName, IEnumerable<string> connectionIds)
        //public async Task SendMessageAsync(string message, IEnumerable<string> groupName)
        public async Task SendMessageAsync(string message, string groupName)
        {
            #region Caller
            // Sadece Server a bildirim gonderen Client ile iletisim kurar.
            //await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion
            #region All
            // Server a bagli olan tum Client lar ile iletisim kurar.
            await Clients.All.SendAsync("receiveMessage", message);
            #endregion
            #region Other
            // Sadece Server a bildirim gonderen Client disinda Server a bagli tum Client lar ile iletisim kurar.
            //await Clients.Others.SendAsync("receiveMessage", message);
            #endregion

            #region Hub Clients Methods
            #region AllExcept
            // Belirtilen Client lar haric Server a bagli tum Client lara bildiride bulunur.
            //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Client
            // Server a baglı Client lar arasinda sadece belirli bir Client a bildirimde bulunur.
            //await Clients.Client(connectionIds.First()).SendAsync("receiveMessage", message);
            #endregion
            #region Clients
            // Server a bagli Client lar arasindan belirtilenlere bildiride bulunur.
            //await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Group
            // Belirtilen gruptaki tum Client lara bildiride bulunur.
            // Once gruplar olusturulmali sonrasinda Client lar gruplara subscribe olmalidir.
            //await Clients.Group(groupName).SendAsync("receiveMessage", message);
            #endregion
            #region GroupExcept
            // Belirtilen gruptaki, belirtilen Client lar disindaki tum Client lara mesaj iletmemizi saglayan bir fonks.
            //await Clients.GroupExcept(groupName, connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Groups
            // Birden cok gruptaki Client lara bildiride bulunmamizi saglayan fonksiyondur.
            //await Clients.Groups(groupName).SendAsync("receiveMessage", message);
            #endregion
            #region OthersInGroup
            // Bildiride bulunan Client haricinde gruptaki tum Client lara bildiride bulunan foksiyondur.
            //await Clients.OthersInGroup(groupName).SendAsync("receiveMessage", message);
            #endregion
            #region User

            #endregion
            #region Users

            #endregion
            #endregion
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }

        public async Task AddGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }
    }
}