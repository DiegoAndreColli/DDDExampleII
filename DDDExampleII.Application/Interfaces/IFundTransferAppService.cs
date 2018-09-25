using DDDExampleII.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDExampleII.Application.Interfaces
{
    public interface IFundTransferAppService
    {
        void TransferFund(Transfer transfer);
    }
}
