using DDDExampleII.Domain.Entities;
using DDDExampleII.Domain.Interfaces.Repositories;
using DDDExampleII.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Entity> ListEntities()
        {
            return UoWRepository.EntityRepository.GetAll().ToList();
        }

        public List<Transfer> ListTransfers()
        {
            return UoWRepository.TransferRepository.GetAll().ToList();
        }

        public bool TransferFund(Transfer transfer)
        {
            FindEntitiesToTransferFund(transfer);
            if (transfer.HasAccountEnoughFunds())
            {
                transfer.UpdateEntitiesAccountBalance();
                return SaveTransferFund(transfer);
            }
            return false;            
        }
        
        private void FindEntitiesToTransferFund(Transfer transfer)
        {
            transfer.To = UoWRepository.EntityRepository.GetById(transfer.To.Id);
            transfer.From = UoWRepository.EntityRepository.GetById(transfer.From.Id);
        }

        private bool SaveTransferFund(Transfer transfer)
        {
            UoWRepository.AccountRepository.Update(transfer.From.Account);
            UoWRepository.TransferRepository.Add(transfer);
            UoWRepository.AccountRepository.Update(transfer.To.Account);
            return UoWRepository.SaveChanges() > 0 ? true : false;
        }
    }
}
