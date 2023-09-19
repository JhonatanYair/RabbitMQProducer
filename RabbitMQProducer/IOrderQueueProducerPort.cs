using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQProducer
{
    public interface IOrderQueueProducerPort
    {
        void EnviarPedido(string pedido);
    }

}
