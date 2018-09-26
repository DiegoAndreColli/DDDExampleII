using DDDExampleII.Application.Interfaces;
using DDDExampleII.Domain.Entities;
using DDDExampleII.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDExampleII.Application
{
    public class FundTransferAppService : IFundTransferAppService
    {
        private readonly IFundTransferService fundTransferService;

        public FundTransferAppService(IFundTransferService fundTransferService)
        {
            this.fundTransferService = fundTransferService;
        }

        public List<Entity> ListEntities()
        {
            return fundTransferService.ListEntities();
        }

        public List<Transfer> ListTransfers()
        {
            return fundTransferService.ListTransfers();
        }

        public bool TransferFund(Transfer transfer)
        {
            return fundTransferService.TransferFund(transfer);
        }
    }
}
