using AruzeServiceBus.Client;
using AruzeServiceBus.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AruzeServiceBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceBusDemoController : ControllerBase
    {
        private readonly IServiceBusDemo _serviceBusDemo;

        public ServiceBusDemoController(IServiceBusDemo serviceBusDemo)
        {
            _serviceBusDemo = serviceBusDemo;
        }

        [HttpPost]
        public async Task<MessageContent> SendMessageToServiceBus([FromBody] MessageContent message)
        {
            var data = await _serviceBusDemo.Sender(message.Message);
            message.Topic = data.Topic;
            message.Message = data.Message;
            message.Status = data.Status;
            return message;
        }
    }
}
