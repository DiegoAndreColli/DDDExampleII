using DDDExampleII.Domain.Entities;
using DDDExampleII.Domain.Interfaces.Repositories;
using DDDExampleII.Domain.Interfaces.Services;
using DDDExampleII.Domain.Services;
using FakeItEasy;
using System;
using Xunit;

namespace XUnitTestDDDExmapleII
{
    public class FundTransferServiceUnitTest
    {
        private Entity GetNewEmptyEntity()
        {
            var acc = new Account();
            var entity = new Entity { Account = acc };
            return entity;
        }

        [Fact]
        public void Test()
        {
            var entityFrom = GetNewEmptyEntity();
            entityFrom.Id = 1;
            entityFrom.Account.Balance = 1000;
            var entityTo = GetNewEmptyEntity();
            entityFrom.Id = 2;
            entityTo.Account.Balance = 1000;
            var value = 100;
            var transfer = new Transfer { From = entityFrom, To = entityTo, Value = value };

            var unitOfWork = A.Fake<IUnitOfWorkRepository>();
            A.CallTo(() => unitOfWork.EntityRepository.GetById(entityFrom.Id)).Returns(entityFrom);
            A.CallTo(() => unitOfWork.EntityRepository.GetById(entityTo.Id)).Returns(entityTo);
            A.CallTo(() => unitOfWork.SaveChanges()).Returns(3);

            var service = new FundTransferService(unitOfWork);
            var transferFundReturn = service.TransferFund(transfer);

            A.CallTo(() => unitOfWork.AccountRepository.Update(entityFrom.Account)).MustHaveHappened();
            A.CallTo(() => unitOfWork.TransferRepository.Add(transfer)).MustHaveHappened();
            A.CallTo(() => unitOfWork.AccountRepository.Update(entityTo.Account)).MustHaveHappened();
            Assert.True(transferFundReturn);

        }
    }
}
