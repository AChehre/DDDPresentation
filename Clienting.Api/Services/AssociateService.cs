using Clienting.Api.EventHandlers;
using Clienting.Domain.AggregatesModel.AssociateAggregate;
using Clienting.Domain.AggregatesModel.AssociateAggregate.Events;
using Clienting.Domain.AggregatesModel.ClientAggregate;

namespace Clienting.Api.Services
{
    public interface IAssociateService
    {
        void AssociateWorkForClient(Associate associate, Client client);
    }

    public class AssociateService : IAssociateService
    {
        private IEventHandler<AssociateReturnedBackToClient> associateReturnBackToClientHandler;
        private IEventHandler<AssociateStartedWorkingAtClient> associateStartedWorkingAtClientHandler;

        public AssociateService(IEventHandler<AssociateReturnedBackToClient> associateReturnBackToClientHandler,
            IEventHandler<AssociateStartedWorkingAtClient> associateStartedWorkingAtClientHandler)
        {
            this.associateReturnBackToClientHandler = associateReturnBackToClientHandler;
            this.associateStartedWorkingAtClientHandler = associateStartedWorkingAtClientHandler;
        }

        public void AssociateWorkForClient(Associate associate, Client client)
        {
            associate.OnAssociateReturnBackToClient += associateReturnBackToClientHandler.Handle;
            associate.OnAssociateStartWorkingAtClient += associateStartedWorkingAtClientHandler.Handle;
            associate.AssociateWorkForClient(client);
        }
    }
}
