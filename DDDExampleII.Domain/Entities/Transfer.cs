using System;
using System.Collections.Generic;
using System.Text;

namespace DDDExampleII.Domain.Entities
{
    public class Transfer
    {
        public int Id { get; set; }
        public virtual Entity From { get; set; }
        public Decimal Value {get; set;}
        public virtual Entity To { get; set; }

        public bool HasAccountEnoughFunds()
        {
            return From.Account.Balance > Value;
        }

        public void UpdateEntitiesAccountBalance()
        {
            From.Account.Balance -= Value;
            To.Account.Balance += Value;
        }
    }
}
