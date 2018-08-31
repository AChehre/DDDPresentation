using Clienting.Domain.AggregatesModel.AssociateAggregate;
using Clienting.Domain.AggregatesModel.AssociateAggregate.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clienting.Api.EventHandlers
{
    public class AssociateStartedWorkingAtClientHandler : IEventHandler<AssociateStartedWorkingAtClient>
    {
        private IAssociateRepository AssociateRepository { get; set; }

        public AssociateStartedWorkingAtClientHandler(IAssociateRepository associateRepository)
        {
            AssociateRepository = associateRepository;
        }

        public void Handle(object source, AssociateStartedWorkingAtClient domainEvent)
        {
            AssociateRepository.CreateAssociateClient(domainEvent.AssociateId, domainEvent.ClientId);
            Publish("ElektraLabManagement.Clienting.Associate.AssociateStartedWorkingAtClient", domainEvent);
        }

        private void Publish(string topic, AssociateStartedWorkingAtClient domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}
