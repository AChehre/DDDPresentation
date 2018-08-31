using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clienting.Domain.AggregatesModel.ClientAggregate;

namespace Clienting.Infrustructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public Client GetClientById(string clientId)
        {
            return new Client() { ClientId = clientId };
        }
    }
}
