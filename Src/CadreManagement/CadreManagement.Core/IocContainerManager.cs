using Castle.Windsor;

namespace CadreManagement.Core
{
    public class IocContainerManager
    {
        public static IWindsorContainer Container { get; }

        static IocContainerManager()
        {
            Container = new WindsorContainer();
        }
    }
}