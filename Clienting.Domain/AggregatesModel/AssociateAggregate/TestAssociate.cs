using System;
using System.Collections.Generic;
using System.Text;
using Clienting.Domain.AggregatesModel.ClientAggregate;

namespace Clienting.Domain.AggregatesModel.AssociateAggregate
{
    public class TestAssociate
    {
        public void IfAssociateUsedToWorkAtClientSheCouldReturnBackToClient()
        {
            var clientId = "CLNT_134679";
            var client = new Client()
            {
                ClientId = clientId
            };
            var associate = new Associate()
            {
                ActiveClients = new List<string>(),
                InActiveClients = new List<string>()
            };
            associate.InActiveClients.Add(clientId);
            associate.AssociateWorkForClient(client);
            //do assertion
        }

        public void IfAssociateHasntWorkedAtClientSheCouldStartWorkingAtClient()
        {
            var clientId = "CLNT_1346790";
            var client = new Client()
            {
                ClientId = clientId
            };
            var associate = new Associate()
            {
                ActiveClients = new List<string>(),
                InActiveClients = new List<string>()
            };
            associate.AssociateWorkForClient(client);
            //do assertion
        }
    }
}
