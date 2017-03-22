using System;
using System.Collections.Concurrent;
using System.Runtime.Remoting.Messaging;
using Castle.Core;

namespace CadreManagement.Core.Uow
{
    public class CurrentUnitOfWorkProvider : ICurrentUnitOfWorkProvider
    {
        private readonly string ContextKey = "Uow.CurrentUnitOfWork";

        private static readonly ConcurrentDictionary<string, IUnitOfWork> UnitOfWorkDictionary =
            new ConcurrentDictionary<string, IUnitOfWork>();

        [DoNotWire]
        public IUnitOfWork Current
        {
            get { return GetCurrentUow(); }
            set { SetCurentUow(value); }
        }

        private IUnitOfWork GetCurrentUow()
        {
            var unitOfWorkKey = CallContext.LogicalGetData(ContextKey) as string;
            if (unitOfWorkKey == null)
            {
                return null;
            }

            IUnitOfWork currentUow;
            if (!UnitOfWorkDictionary.TryGetValue(unitOfWorkKey, out currentUow))
            {
                CallContext.FreeNamedDataSlot(unitOfWorkKey);
            }

            return currentUow;
        }

        private void SetCurentUow(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                ExitFromCurrentUowScope();
                return;
            }

            var unitOfWorkKey = CallContext.LogicalGetData(ContextKey) as string;
            if (unitOfWorkKey != null)
            {
                ExitFromCurrentUowScope();
               // throw new Exception("Don't set unitOfWork once agin");
            }
            UnitOfWorkDictionary.TryAdd(unitOfWork.Id, unitOfWork);
            CallContext.LogicalSetData(ContextKey, unitOfWork.Id);
        }

        private void ExitFromCurrentUowScope()
        {
            var unitOfWorkKey = CallContext.LogicalGetData(ContextKey) as string;
            if (unitOfWorkKey == null)
            {
                return;
            }

            IUnitOfWork currentUnitOfWork;
            UnitOfWorkDictionary.TryRemove(unitOfWorkKey, out currentUnitOfWork);
            CallContext.FreeNamedDataSlot(ContextKey);
        }
    }
}