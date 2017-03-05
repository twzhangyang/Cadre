using Castle.Windsor;

namespace CadreManagement.DomainUnitTests
{
    public abstract class ScenarioBase
    {
        protected IWindsorContainer Container { get; }


        protected ScenarioBase(IWindsorContainer container)
        {
            Container = container;
        }

        public abstract void Execute();
    }
}