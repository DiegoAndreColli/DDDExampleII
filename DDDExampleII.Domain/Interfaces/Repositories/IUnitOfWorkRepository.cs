using DDDExampleII.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDExampleII.Domain.Interfaces.Repositories
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        IBaseRepository<Book> BookRepository { get; }

        IEntityRepository EntityRepository { get; }

        ITransferRepository TransferRepository { get; }

        IAccountRepository AccountRepository { get; }

        int Commit();
    }
}
