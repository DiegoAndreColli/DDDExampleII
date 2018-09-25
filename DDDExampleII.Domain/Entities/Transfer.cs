using System;
using System.Collections.Generic;
using System.Text;

namespace DDDExampleII.Domain.Entities
{
    public class Transfer
    {
        public Entity From { get; set; }
        public Decimal Value {get; set;}
        public Entity To { get; set; }
    }
}
