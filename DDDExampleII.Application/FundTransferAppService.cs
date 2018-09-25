using DDDExampleII.Application.Interfaces;
using DDDExampleII.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDExampleII.Application
{
    public class FundTransferAppService : IFundTransferAppService
    {
        private readonly IFundTransferAppService fundTransferAppService;

        public FundTransferAppService(IFundTransferAppService fundTransferAppService)
        {
            this.fundTransferAppService = fundTransferAppService;
        }

        public void TransferFund(Transfer transfer)
        {
            throw new NotImplementedException();
        }
    }
}
