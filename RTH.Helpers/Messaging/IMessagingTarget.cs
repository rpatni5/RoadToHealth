using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Helpers.Messaging
{
    public interface IMessagingTarget
    {
        Guid Token { get; }
        void ReceiveMessage(Message msg);
    }
}
