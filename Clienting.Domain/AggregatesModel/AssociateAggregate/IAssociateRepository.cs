namespace Clienting.Domain.AggregatesModel.AssociateAggregate
{
    public interface IAssociateRepository
    {
        Associate LoadAssociateWithClients(string associateId);
        void CreateAssociateClient(string associateId, string clientId);
        void ReactiveAssociateOfClient(string associateId, string clientId);
    }
}
