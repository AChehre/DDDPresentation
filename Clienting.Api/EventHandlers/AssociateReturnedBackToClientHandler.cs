using Clienting.Domain.AggregatesModel.AssociateAggregate;
using Clienting.Domain.AggregatesModel.AssociateAggregate.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clienting.Api.EventHandlers
{
    public class AssociateReturnedBackToClientHandler : IEventHandler<AssociateReturnedBackToClient>
    {
        private IAssociateRepository AssociateRepository { get; set; }

        public AssociateReturnedBackToClientHandler(IAssociateRepository associateRepository)
        {
            AssociateRepository = associateRepository;
        }

        public void Handle(object source, AssociateReturnedBackToClient domainEvent)
        {
            AssociateRepository.ReactiveAssociateOfClient(domainEvent.AssociateId, domainEvent.ClientId);
            Publish("ElektraLabManagement.Clienting.Associate.AssociateReturnedBackToClient", domainEvent);
        }

        private void Publish(string topic, AssociateReturnedBackToClient domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}
