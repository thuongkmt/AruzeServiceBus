using AruzeServiceBus.Model;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace AruzeServiceBus.Client
{
    public class ServiceBusDemo: IServiceBusDemo
    {
        private ServiceBusClient _client;
        public ServiceBusDemo(IConfiguration configuration)
        {
            _client = new ServiceBusClient(configuration["ServiceBus:ConnectionString"].ToString());
        }

        public async Task<MessageContent> Sender(string MessageContent)
        {
            string topicName = ServiceBusTopic.CITYCONNECT_API_TOPIC;
            ServiceBusSender sender;
            sender = _client.CreateSender(topicName);
            using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();
            messageBatch.TryAddMessage(new ServiceBusMessage($"Message: {MessageContent}"));
            bool sendStatus = true;
            try
            {
               await sender.SendMessagesAsync(messageBatch);
            }
            catch(Exception ex)
            {
                //log ex
                sendStatus = false;
            }
            finally
            {
                await sender.DisposeAsync();
                await _client.DisposeAsync();
            }

            return new MessageContent { Message = MessageContent, Topic = topicName, Status = sendStatus };
        }

        public async Task Receiver()
        {

        }
    }
}
