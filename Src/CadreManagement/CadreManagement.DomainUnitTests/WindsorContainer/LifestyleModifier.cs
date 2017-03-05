using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ModelBuilder;

namespace CadreManagement.DomainUnitTests.WindsorContainer
{
    public class LifestyleModifier : IContributeComponentModelConstruction
    {
        private readonly LifestyleType _originalLifestyle;
        private readonly LifestyleType _newLifestyleType;

        public LifestyleModifier(
            LifestyleType originalLifestyle = LifestyleType.PerWebRequest,
            LifestyleType newLifestyleType = LifestyleType.Scoped)
        {
            _originalLifestyle = originalLifestyle;
            _newLifestyleType = newLifestyleType;
        }

        public void ProcessModel(IKernel kernel,ComponentModel model)
        {
            if (model.LifestyleType == _originalLifestyle)
                model.LifestyleType = _newLifestyleType;
        }
    }
}