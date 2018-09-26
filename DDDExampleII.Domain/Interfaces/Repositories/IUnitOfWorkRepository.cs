using DDDExampleII.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDExampleII.Domain.Interfaces.Repositories
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        IBaseRepository<Book> BookRepository { get; }

        IEntityRepository EntityRepository { get; }

        ITransferRepository TransferRepository { get; }

        IAccountRepository AccountRepository { get; }

        int SaveChanges();

        IContextTransaction BeginTransaction();        
    }
}
