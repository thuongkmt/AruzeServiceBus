using AruzeServiceBus.Model;
using System;
using System.Threading.Tasks;

namespace AruzeServiceBus.Client
{
    public interface IServiceBusDemo
    {
        public EventHandler eventHandler(EventArgs arg);
        public Task<MessageContent> Sender(string MessageContent);
        public Task Receiver(EventArgs arg);
    }
}
