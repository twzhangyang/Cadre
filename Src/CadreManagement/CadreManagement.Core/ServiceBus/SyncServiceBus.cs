using Castle.Windsor;

namespace CadreManagement.Core.ServiceBus
{
    public class SyncServiceBus : IServiceBus
    {
        private readonly IWindsorContainer _container;

        public SyncServiceBus(IWindsorContainer container)
        {
            _container = container;
        }

        public void Publish<TMessage>(TMessage message)
        {
            var handlers = _container.ResolveAll<IHandleMessage<TMessage>>();
            var syncHandlerInvoker = new SyncHandlerInvoker();
            foreach (var messageHandler in handlers)
            {
                syncHandlerInvoker.Invoke(messageHandler, message);
                _container.Release(messageHandler);
            }
        }
    }
}