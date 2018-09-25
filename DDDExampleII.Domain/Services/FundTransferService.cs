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
        //private readonly IAccountRepository accountRepository;
        //private readonly IBookRepository bookRepository;
        //private readonly IEntityRepository entityRepository;
        private readonly ITransferRepository transferRepository;

        public FundTransferService(ITransferRepository transferRepository)
        {
            this.transferRepository = transferRepository;
        }

        public bool TransferFund(Transfer transfer)
        {
            throw new NotImplementedException();
        }
    }
}
