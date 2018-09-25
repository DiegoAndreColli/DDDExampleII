using DDDExampleII.Domain.Entities;
using DDDExampleII.Domain.Interfaces.Repositories;
using DDDExampleII.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDExampleII.Domain.Services
{
    public class FundTransferService : IFundTransferService
    {
        private readonly IUnitOfWorkRepository UoWRepository;

        public FundTransferService(IUnitOfWorkRepository unitOfWorkRepository)
        {
            UoWRepository = unitOfWorkRepository;
        }

        public bool TransferFund(Transfer transfer)
        {
            throw new NotImplementedException();
        }
    }
}
