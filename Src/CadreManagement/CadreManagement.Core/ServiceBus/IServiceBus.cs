namespace CadreManagement.Core.ServiceBus
{
    public interface IServiceBus
    {
        void Publish<TMessage>(TMessage message);
    }
}