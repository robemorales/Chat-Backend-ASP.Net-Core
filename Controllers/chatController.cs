using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ChatSignalR.Hubs;
using ChatSignalR.ReqDTO;


namespace ChatSignalR.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class chatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public chatController(IHubContext<ChatHub> hubContext) 
        {
            _hubContext = hubContext;
        }

        [Route("send")]
        [HttpPost]
        public IActionResult SendRequest([FromBody] MessageDTO msg) 
        {
            _hubContext.Clients.All.SendAsync("ReciveOne", msg.user, msg.msgText);
            return Ok();
        }

    }
}
