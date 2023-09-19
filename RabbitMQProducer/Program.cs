using RabbitMQ.Client;
using RabbitMQProducer;
using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost", // Cambia por la dirección de tu servidor RabbitMQ
            UserName = "guest", // Cambia por tu nombre de usuario
            Password = "guest"  // Cambia por tu contraseña
        };

        try
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var orderQueueProducer = new RabbitMQOrderQueueProducerPort(channel);

                while (true)
                {
                    Console.Write("Ingrese un pedido (o 'q' para salir): ");
                    string pedido = Console.ReadLine();

                    if (pedido.ToLower() == "q")
                        break;

                    // Enviar el pedido a RabbitMQ
                    orderQueueProducer.EnviarPedido(pedido);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error de conexión a RabbitMQ: {ex.Message}");
        }
    }
}
