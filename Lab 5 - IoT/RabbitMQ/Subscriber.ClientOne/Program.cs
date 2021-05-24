using System;
using Shared;

namespace Subscriber.ClientOne
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = "localhost";
            string queue = QueueNames.FirstRabbitMQ;

            Console.WriteLine("ClientOne. Press any key for quit.");

            var rabbitMQManager = new RabbitMQManager(host);

            // Connect client to RabbitMQ manager
            using (var connection = rabbitMQManager.Factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Subscribe queue
                rabbitMQManager.SubscribeQueue(channel, queue, (message) =>
                {
                    Console.WriteLine($"Message is received! >>> Message: '{message}'");
                });
                Console.ReadKey();
            }
        }
    }
}
