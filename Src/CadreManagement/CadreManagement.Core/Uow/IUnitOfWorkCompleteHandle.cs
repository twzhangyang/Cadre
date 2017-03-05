using System;

namespace CadreManagement.Core.Uow
{
    public interface IUnitOfWorkCompleteHandle : IDisposable
    {
        void Complete();
    }
}