using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Interfaces
{
    public interface IMessageConsumer
    {
        void Consume<T>(string queueName, Action<T> handleMessage);
    }
}
