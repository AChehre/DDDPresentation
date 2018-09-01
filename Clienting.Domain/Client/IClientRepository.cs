namespace Clienting.Domain.AggregatesModel.ClientAggregate
{
    public interface IClientRepository
    {
        Client GetClientById(string clientId);
    }
}
