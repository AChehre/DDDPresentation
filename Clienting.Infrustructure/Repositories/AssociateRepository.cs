using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clienting.Domain.AggregatesModel.AssociateAggregate;

namespace Clienting.Infrustructure.Repositories
{
    public class AssociateRepository : IAssociateRepository
    {
        public Associate LoadAssociateWithClients(string associateId)
        {
            var associate = new Associate() { AssociateId = associateId };
            return associate;
        }

        public void CreateAssociateClient(string associateId, string clientId)
        {
            
        }

        public void ReactiveAssociateOfClient(string associateId, string clientId)
        {
            
        }
    }
}
