namespace CadreManagement.Core.Uow
{
    public interface IUnitOfWorkManager
    {
        IUnitOfWork Current { get; }

        IUnitOfWorkCompleteHandle Begin();

        IUnitOfWorkCompleteHandle Begin(UnitOfWorkOptions options);
    }
}