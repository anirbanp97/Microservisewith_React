using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Interfaces
{
    public interface IMessagePublisher
    {
        void Publish<T>(T message, string queueName);
    }
}
