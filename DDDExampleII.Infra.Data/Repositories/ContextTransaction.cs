using DDDExampleII.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDExampleII.Infra.Data.Repositories
{
    //proxy
    public class ContextTransactionRepository : IContextTransaction
    {
        private readonly IDbContextTransaction dbContextTransaction;
  
        public ContextTransactionRepository(IDbContextTransaction dbContextTransaction)
        {
            this.dbContextTransaction = dbContextTransaction;
        }

        public Guid TransactionId => dbContextTransaction.TransactionId;

        public void Commit()
        {
            dbContextTransaction.Commit();
        }

        public void Rollback()
        {
            dbContextTransaction.Rollback();
        }
    }
}
