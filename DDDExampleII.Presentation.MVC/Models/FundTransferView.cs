using DDDExampleII.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDExampleII.Presentation.MVC.Models
{
    public class FundTransferView
    {
        public Transfer Transfer { get; set; }
        public List<Entity> Entities { get; set; }

    }
}
