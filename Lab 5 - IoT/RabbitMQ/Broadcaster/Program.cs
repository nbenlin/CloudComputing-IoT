using System;
using Shared;

namespace Broadcaster
{
    class Program
    {
        public static void Main(string[] args)
        {
            string hostName = "localhost";
            var RabbitMQManager = new RabbitMQManager(hostName);

            while (true)
            {
                Console.WriteLine("Enter your message or type 'q' for exit:");
                string userMessage = Console.ReadLine();

                // If client typed message
                if (string.IsNullOrEmpty(userMessage))
                {
                    Console.WriteLine("Your message is sending.");
                    continue;
                }

                // If client typed q for exit
                if (userMessage == "q")
                {
                    return;
                }

                Console.WriteLine("[START]");
                try
                {
                    // Message will sended to queue which named FirstRabbit ( defined in QueueNames file )
                    RabbitMQManager.SendMessage(QueueNames.FirstRabbitMQ, userMessage);
                    Console.WriteLine("[DONE]");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"[Failed to send message, {ex.Message}]");
                    Console.ReadKey();
                    return;
                }


            }
        }
    }
}
