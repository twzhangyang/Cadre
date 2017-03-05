using Castle.Windsor;

namespace CadreManagement.Core.Uow
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        private readonly ICurrentUnitOfWorkProvider _currentUnitOfWorkProvider;
        private readonly IWindsorContainer _windsorContainer;
        public IUnitOfWork Current => _currentUnitOfWorkProvider.Current;

        public UnitOfWorkManager(ICurrentUnitOfWorkProvider currentUnitOfWorkProvider,
            IWindsorContainer windsorContainer)
        {
            _currentUnitOfWorkProvider = currentUnitOfWorkProvider;
            _windsorContainer = windsorContainer;
        }

        public IUnitOfWorkCompleteHandle Begin()
        {
            return Begin(new UnitOfWorkOptions());
        }

        public IUnitOfWorkCompleteHandle Begin(UnitOfWorkOptions options)
        {
            var uow = _windsorContainer.Resolve<IUnitOfWork>();

            uow.Begin(options);
            _currentUnitOfWorkProvider.Current = uow;

            uow.RegisterCompleted(() => _currentUnitOfWorkProvider.Current = null);
            uow.RegisterDisposed(() => _currentUnitOfWorkProvider.Current = null);
            uow.RegisterDisposed(() => _windsorContainer.Release(uow));

            return uow;
        }
    }
}