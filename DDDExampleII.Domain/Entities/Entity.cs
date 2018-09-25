using System;
using System.Collections.Generic;
using System.Text;

namespace DDDExampleII.Domain.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public virtual Account Account { get; set;}
    }
}
