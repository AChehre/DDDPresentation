using System;
using System.Collections.Generic;
using System.Text;

namespace Clienting.Domain.AggregatesModel.ClientAggregate
{
    public interface IClientRepository
    {
        Client GetClientById(string clientId);
    }
}
