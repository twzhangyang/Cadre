using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Transactions;

namespace CadreManagement.Core.Uow.EntityFramework
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly DefaultUnitOfWorkOptions _defaultUnitOfWorkOptions;
        private readonly DbContext _dbContext;
        private TransactionScope _transactionScope;
        private readonly List<Action> _completed;
        private Action _disposed;
        private Action _failed;
        public string Id { get; }

        public EfUnitOfWork(DefaultUnitOfWorkOptions defaultUnitOfWorkOptions, DbContext dbContext)
        {
            _defaultUnitOfWorkOptions = defaultUnitOfWorkOptions;
            _dbContext = dbContext;
            Id = Guid.NewGuid().ToString("n");
            _completed = new List<Action>();
        }

        public void Begin(UnitOfWorkOptions options)
        {
            _transactionScope = new TransactionScope(
                options.TransactionScopeOption.GetValueOrDefault(_defaultUnitOfWorkOptions.TransactionScopeOption),
                new TransactionOptions()
                {
                    IsolationLevel = options.IsolationLevel.GetValueOrDefault(_defaultUnitOfWorkOptions.IsolationLevel),
                    Timeout = options.Timeout.GetValueOrDefault(_defaultUnitOfWorkOptions.Timeout)
                });
        }

        public void Dispose()
        {
            _transactionScope.Dispose();
            _disposed?.Invoke();
        }

        public void Complete()
        {
            try
            {
                _dbContext.SaveChanges();
                _transactionScope?.Complete();

                _completed.ForEach(c => c.Invoke());
            }
            catch
            {
                _failed?.Invoke();
                throw;
            }
        }

        public void RegisterCompleted(Action action)
        {
            Contract.Requires(action != null);

            _completed.Add(action);
        }

        public void RegisterDisposed(Action action)
        {
            Contract.Requires(action != null);

            _disposed = action;
        }

        public void RegisterFailed(Action action)
        {
            Contract.Requires(action != null);

            _failed = action;
        }
    }
}