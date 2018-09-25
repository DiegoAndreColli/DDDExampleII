using System;
using System.Collections.Generic;
using System.Text;

namespace DDDExampleII.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public String Code { get; set; }
        public Decimal Balance { get; set; }
    }
}
