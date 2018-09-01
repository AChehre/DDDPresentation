namespace Clienting.Domain.AggregatesModel.AssociateAggregate
{
    public interface IAssociateRepository
    {
        void CreateAssociateClient(string associateId, string clientId);
        Associate LoadAssociateWithClients(string associateId);
        void ReactiveAssociateOfClient(string associateId, string clientId);
    }
}
