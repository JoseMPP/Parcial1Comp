
namespace apiDoble.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Azure.Messaging.ServiceBus;
    using Newtonsoft.Json;
    using apiDoble.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpPost]

        public async Task<bool> EnviarAsync([FromBody] Data data)
        {
            string connectionString2 = "Endpoint=sb://josepizarro.servicebus.windows.net/;SharedAccessKeyName=Enviar;SharedAccessKey=5V7lUUVCQ0y4GOucId5weDiXiqT7waECA1cYvheRmiM=;EntityPath=qimpar";
            string connectionString = "Endpoint=sb://josepizarro.servicebus.windows.net/;SharedAccessKeyName=Enviar;SharedAccessKey=3cdUpVCNX3wYroXXMZJlna2IQxq0wy7G2XUvzf6MwEU=;EntityPath=qpar";
            string queueName = "qpar";
            string queueName2 = "qimpar";
            string mensaje = JsonConvert.SerializeObject(data);

        
            
            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                // create a sender for the queue 
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(mensaje);

                // send the message
                await sender.SendMessageAsync(message);
                Console.WriteLine($"Sent a single message to the queue: {queueName}");
            }
            await using (ServiceBusClient client = new ServiceBusClient(connectionString2))
            {
                // create a sender for the queue 
                ServiceBusSender sender = client.CreateSender(queueName2);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(mensaje);

                // send the message
                await sender.SendMessageAsync(message);
                Console.WriteLine($"Sent a single message to the queue: {queueName2}");
            }
            return true;
        }
    }
}