using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clienting.Api.EventHandlers
{
    public interface IEventHandler<T>
    {
        void Handle(object source, T domainEvent);
    }
}
