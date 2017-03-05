namespace CadreManagement.Core.ServiceBus
{
    public interface IHandleMessage<in TMessage>
    {
        void Handle(TMessage message);
    }
}