using System;
using System.Collections.Generic;
using System.Text;
using DDDExampleII.Domain.Entities;
using DDDExampleII.Domain.Interfaces.Repositories;
using DDDExampleII.Infra.Data.Context;

namespace DDDExampleII.Infra.Data.Repositories
{
    public class EntityRepository : BaseRepository<Entity>, IEntityRepository
    {
        public EntityRepository(DDDExampleIIContext db) : base(db)
        {
        }
    }
}
