using System;
using System.Collections.Generic;
using System.Text;

namespace DDDExampleII.Domain.Entities
{
    public class Book
    {
        public virtual ICollection<Transfer> Transfers { get; set; }
    }
}
