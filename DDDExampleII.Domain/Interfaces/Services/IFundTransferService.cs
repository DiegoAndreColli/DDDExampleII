using DDDExampleII.Domain.Entities;
using DDDExampleII.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDExampleII.Domain.Interfaces.Services
{
    public interface IFundTransferService
    {
        bool TransferFund(Transfer transfer);
        List<Transfer> ListTransfers();
    }
}
