using DDDExampleII.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDExampleII.Infra.Data.Context
{
    public class DDDExampleIIContext : DbContext
    {
        public DDDExampleIIContext(DbContextOptions<DDDExampleIIContext> options)
         : base(options)
        { }

        public DbSet<Account> Accounts{ set; get; }

        public DbSet<Book> Books { set; get; }

        public DbSet<Entity> Entities { set; get; }

        public DbSet<Book> Transfers { set; get; }

    }
}
