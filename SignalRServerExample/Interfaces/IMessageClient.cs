using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRServerExample.Interfaces
{
    // Strogly Typed Hubs ozelligini kullanmak icin olusturdugumuz interface
    public interface IMessageClient
    {
        Task Clients(List<string> clients);
        Task UserJoined(string connectionId);
        Task UserLeft(string connectionId);
    }
}