using RabbitMQ.Client;
using RabbitMQProducer;
using System;
using System.Text;

namespace RabbitMQProducer;

public class RabbitMQOrderQueueProducerPort : IOrderQueueProducerPort
{
    private readonly IModel _channel;

    public RabbitMQOrderQueueProducerPort(IModel channel)
    {
        _channel = channel;
        _channel.QueueDeclare("order-queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
    }

    public void EnviarPedido(string pedido)
    {
        var body = Encoding.UTF8.GetBytes(pedido);
        _channel.BasicPublish(exchange: "", routingKey: "order-queue", basicProperties: null, body: body);
        Console.WriteLine($"Pedido enviado a RabbitMQ: {pedido}");
    }
}
