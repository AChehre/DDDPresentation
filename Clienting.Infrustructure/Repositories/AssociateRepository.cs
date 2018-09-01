using Clienting.Domain.AggregatesModel.AssociateAggregate;

namespace Clienting.Infrustructure.Repositories
{
    public class AssociateRepository : IAssociateRepository
    {
        public void CreateAssociateClient(string associateId, string clientId)
        {

        }

        public Associate LoadAssociateWithClients(string associateId)
        {
            var associate = new Associate() { AssociateId = associateId };
            return associate;
        }

        public void ReactiveAssociateOfClient(string associateId, string clientId)
        {
            
        }
    }
}
