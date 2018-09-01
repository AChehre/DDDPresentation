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
