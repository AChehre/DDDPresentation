using Clienting.Domain.AggregatesModel.AssociateAggregate;
using Clienting.Domain.AggregatesModel.ClientAggregate;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Clienting.UnitTest.Domain
{
    public class TestAssociate
    {
        [Fact]
        public void IfAssociateUsedToWorkAtClientSheCouldReturnBackToClient()
        {
            var associate = GetAssociateInstance();
            var client = GetClientInstance();

            associate.InActiveClients.Add(client.ClientId);
            associate.AssociateWorkForClient(client);
            Assert.DoesNotContain(associate.InActiveClients, clientId => clientId == client.ClientId);
            Assert.Contains(associate.ActiveClients, clientId => clientId == client.ClientId);
        }

        [Fact]
        public void IfAssociateHasntWorkedAtClientSheCouldStartWorkingAtClient()
        {
            var associate = GetAssociateInstance();
            var client = GetClientInstance();

            associate.AssociateWorkForClient(client);
            Assert.Contains(associate.ActiveClients, clientId => clientId == client.ClientId);
        }

        private Associate GetAssociateInstance()
        {
            var associate = new Associate()
            {
                AssociateId = "ASCT_865320",
                ActiveClients = new List<string>(),
                InActiveClients = new List<string>()
            };
            return associate;
        }

        private Client GetClientInstance()
        {
            var client = new Client()
            {
                ClientId = "CLNT_1346790"
            };
            return client;
        }
    }
}
