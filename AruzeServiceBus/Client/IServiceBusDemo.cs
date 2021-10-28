using AruzeServiceBus.Model;
using System.Threading.Tasks;

namespace AruzeServiceBus.Client
{
    public interface IServiceBusDemo
    {
        public Task<MessageContent> Sender(string MessageContent);
        public Task Receiver();
    }
}
