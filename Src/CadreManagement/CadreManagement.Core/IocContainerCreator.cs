using Castle.Windsor;

namespace CadreManagement.Core
{
    public class IocContainerCreator
    {
        public static IWindsorContainer Container { get; }

        static IocContainerCreator()
        {
            Container = new WindsorContainer();
        }
    }
}