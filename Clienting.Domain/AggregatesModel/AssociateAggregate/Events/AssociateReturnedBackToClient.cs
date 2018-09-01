namespace Clienting.Domain.AggregatesModel.AssociateAggregate.Events
{
    public class AssociateReturnedBackToClient
    {
        public AssociateReturnedBackToClient(string associateId, string clientId)
        {
            AssociateId = associateId;
            ClientId = clientId;
        }

        public string AssociateId { get; set; }
        public string ClientId { get; set; }
    }
}
