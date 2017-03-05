using System;

namespace CadreManagement.Core
{
    public class AggregateRoot<TAggregate> : IAggregateRoot
        where TAggregate : AggregateRoot<TAggregate>
    {
        public Guid Id { get; protected set; }
    }
}