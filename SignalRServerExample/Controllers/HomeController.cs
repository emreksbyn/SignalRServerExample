using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Business;
using SignalRServerExample.Hubs;
using System.Threading.Tasks;

namespace SignalRServerExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // Belirli islemler busines mantiklari kullanilmasi gerekiyorsa IHubContext interface si Business class i uzerinden kullanilmasi daha uygun olur.
        readonly MyBusiness _myBusiness;
        // Fakat sadece istek yollamak gibi tek bir islem yapilacaksa Business class inda ugrasmaya gerek yoktur. Controller class inda da dogrudan cagirip kullanabiliriz.
        readonly IHubContext<MyHub> _hubContext;
        public HomeController(MyBusiness myBusiness, IHubContext<MyHub> hubContext)
        {
            _myBusiness = myBusiness;
            _hubContext = hubContext;
        }

        [HttpGet("{message}")]
        public async Task<IActionResult> Index(string message)
        {
            //await _hubContext.Clients.All.SendAsync("receiveMessage", message);
            await _myBusiness.SendMessageAsync(message);
            return Ok();
        }
    }
}