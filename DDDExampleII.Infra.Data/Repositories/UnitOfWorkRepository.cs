using DDDExampleII.Domain.Entities;
using DDDExampleII.Domain.Interfaces.Repositories;
using DDDExampleII.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDExampleII.Infra.Data.Repositories
{
    class UnitOfWorkRepository : IUnitOfWorkRepository
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

        public int Commit()
        {
            return context.SaveChanges();
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
