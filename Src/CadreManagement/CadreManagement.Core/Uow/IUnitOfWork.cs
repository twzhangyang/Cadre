namespace CadreManagement.Core.Uow
{
    public interface IUnitOfWork : IActiveUnitOfWork, IUnitOfWorkCompleteHandle
    {
        string Id { get; }

        void Begin(UnitOfWorkOptions options);
    }
}