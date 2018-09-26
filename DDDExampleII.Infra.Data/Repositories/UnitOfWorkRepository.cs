using DDDExampleII.Domain.Entities;
using DDDExampleII.Domain.Interfaces.Repositories;
using DDDExampleII.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDExampleII.Infra.Data.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private bool disposed;
        private readonly DDDExampleIIContext context;
        private IBaseRepository<Book> bookRepository;
        private IEntityRepository entityRepository;
        private ITransferRepository transferRepository;
        private IAccountRepository accountRepository;
        
        public UnitOfWorkRepository(DDDExampleIIContext context = null)
        {
            this.context = context;
        }
        
        public IBaseRepository<Book> BookRepository
        {
            get
            {
                if (bookRepository == null)
                {
                    bookRepository = new BaseRepository<Book>(context);
                }
                return bookRepository;
            }
        }

        public IEntityRepository EntityRepository
        {
            get
            {
                if (entityRepository == null)
                {
                    entityRepository = new EntityRepository(context);
                }
                return entityRepository;
            }
        }

        public ITransferRepository TransferRepository
        {
            get
            {
                if (transferRepository == null)
                {
                    transferRepository = new TransferRepository(context);
                }
                return transferRepository;
            }
        }

        public IAccountRepository AccountRepository
        {
            get
            {
                if (accountRepository == null)
                {
                    accountRepository = new AccountRepository(context);
                }
                return accountRepository;
            }
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        //seems like Transactions already exists https://stackoverflow.com/a/25004973/4482337 , so
        public IContextTransaction BeginTransaction()
        {
            return new ContextTransactionRepository(context.Database.BeginTransaction());
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
