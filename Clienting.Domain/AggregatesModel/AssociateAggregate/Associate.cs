﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clienting.Domain.AggregatesModel.AssociateAggregate.Events;
using Clienting.Domain.AggregatesModel.ClientAggregate;

namespace Clienting.Domain.AggregatesModel.AssociateAggregate
{
    public class Associate
    {
        public event EventHandler<AssociateReturnedBackToClient> OnAssociateReturnBackToClient;
        public event EventHandler<AssociateStartedWorkingAtClient> OnAssociateStartWorkingAtClient;

        public IList<string> ActiveClients { get; set; }
        public IList<string> InActiveClients { get; set; }

        public string AssociateId { get; set; }

        public void AssociateWorkForClient(Client client)
        {
            if (AssociateUsedToWorkForClient(client))
            {
                ReturnBackToClient(client);
            }
            else
            {
                StartWorkingAtClient(client);
            }
        }

        private void ReturnBackToClient(Client client)
        {
            InActiveClients = InActiveClients.Where(cl => cl != client.ClientId).ToList();
            ActiveClients.Add(client.ClientId);
            OnAssociateReturnBackToClient(this, new AssociateReturnedBackToClient(AssociateId, client.ClientId));
        }

        private bool AssociateUsedToWorkForClient(Client client)
        {
            return InActiveClients.Any(cl => cl == client.ClientId);
        }

        private void StartWorkingAtClient(Client client)
        {
            ActiveClients.Add(client.ClientId);
            OnAssociateStartWorkingAtClient(this, new AssociateStartedWorkingAtClient(AssociateId, client.ClientId));
        }
    }
}