using Clienting.Domain.AggregatesModel.AssociateAggregate;
using Clienting.Domain.AggregatesModel.AssociateAggregate.Events;
using System;

namespace Clienting.Api.EventHandlers
{
    public class AssociateReturnedBackToClientHandler : IEventHandler<AssociateReturnedBackToClient>
    {
        private IAssociateRepository AssociateRepository;

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
