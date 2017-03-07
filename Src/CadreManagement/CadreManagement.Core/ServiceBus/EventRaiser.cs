using CadreManagement.Core.Uow;

namespace CadreManagement.Core.ServiceBus
{
    public class EventRaiser
    {
        public static void RaiseEvent<TEvent>(TEvent evt)
        {
            var unitOfWorkManager = IocContainerCreator.Container.Resolve<IUnitOfWorkManager>();
            var serviceBus = IocContainerCreator.Container.Resolve<IServiceBus>();

            unitOfWorkManager.Current.RegisterCompleted(() => serviceBus.Publish(evt));
        }
    }
}