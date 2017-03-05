using Castle.Core;
using Castle.Windsor;

namespace CadreManagement.DomainUnitTests.WindsorContainer
{
    public static class WindsorTestingExtensions
    {
        public static void ChangeComponentsLifestyleToScoped(this IWindsorContainer container)
        {
            container.Kernel.ComponentModelBuilder.AddContributor(
              new LifestyleModifier(originalLifestyle: LifestyleType.PerWebRequest, newLifestyleType: LifestyleType.Scoped)
              );
        }
    }
}