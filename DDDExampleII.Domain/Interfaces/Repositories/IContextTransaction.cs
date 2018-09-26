using System;
using System.Collections.Generic;
using System.Text;

namespace DDDExampleII.Domain.Interfaces.Repositories
{
    public interface IContextTransaction
    {
        //
        // Summary:
        //     Gets the transaction identifier.
        Guid TransactionId { get; }

        //
        // Summary:
        //     Commits all changes in the current transaction.
        void Commit();
        //
        // Summary:
        //     Discards all changes in the current transaction.
        void Rollback();
    }
}
