using System;
using System.Transactions;

namespace CadreManagement.Core.Uow
{
    public class UnitOfWorkOptions
    {
        public TimeSpan? Timeout { get; set; }

        public TransactionScopeOption? TransactionScopeOption { get; set; }

        public IsolationLevel? IsolationLevel { get; set; }
    }
}