using DDDExampleII.Domain.Entities;
using DDDExampleII.Domain.Interfaces.Repositories;
using FakeItEasy;
using Xunit;


namespace XUnitTestDDDExmapleII
{
    public class TransferUnitTest
    {
        private Transfer GetNewEmptyTransfer()
        {
            var acc_1 = new Account();
            var acc_2 = new Account();
            var ent_1 = new Entity { Account = acc_1 };
            var ent_2 = new Entity { Account = acc_2 };
            var transfer = new Transfer {From = ent_1, To = ent_2 };
            return transfer;
        }


        [Fact]
        public void TestTransferUpdateEntitiesAccountBalance()
        {
            var transfer = GetNewEmptyTransfer();
            transfer.From.Account.Balance = 1000;
            transfer.To.Account.Balance = 1000;
            transfer.Value = 100;
            var expectedBalanceFrom = 900;
            var expectedBalanceTo = 1100;
            transfer.UpdateEntitiesAccountBalance();

            Assert.Equal(expectedBalanceFrom, transfer.From.Account.Balance);
            Assert.Equal(expectedBalanceTo, transfer.To.Account.Balance);
        }


        [Fact]
        public void TestHasEnoughFunds()
        {
            var transfer = GetNewEmptyTransfer();
            transfer.From.Account.Balance = 1000;
            transfer.To.Account.Balance = 1000;
            transfer.Value = 100;
            Assert.True(transfer.HasAccountEnoughFunds());

            transfer = GetNewEmptyTransfer();
            transfer.From.Account.Balance = 1000;
            transfer.To.Account.Balance = 1000;
            transfer.Value = 1100;
            Assert.False(transfer.HasAccountEnoughFunds());
        }


    }
}
