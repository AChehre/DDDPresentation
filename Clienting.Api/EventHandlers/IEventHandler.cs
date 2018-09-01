namespace Clienting.Api.EventHandlers
{
    public interface IEventHandler<T>
    {
        void Handle(object source, T domainEvent);
    }
}
