using DDDExampleII.Domain.Entities;
using DDDExampleII.Domain.Interfaces.Repositories;
using DDDExampleII.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDExampleII.Infra.Data.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(DDDExampleIIContext db) : base(db)
        {
        }
    }
}
