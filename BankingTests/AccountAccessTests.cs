using AccountsAccess.Contracts.Requests;
using AccountsAccess.Service.Implementation;
using StorageImplementation.Accounts;

namespace BankingTests
{
    public class Tests
    {
        [Test]
        public async Task CreateAccount_CanCreate()
        {
            var access = new AccountAccess(new Accounts_Mock());
            var result = await access.CreateAccount(new CreateAccountRequest
            {
                UserName = "test tester",
                StartingFunds = 100m
            });

            Assert.IsNotNull(result);
            Assert.IsTrue(result.TransactionSucceeded);
            Assert.IsNotNull(result.Account);
        }

        [Test]
        public async Task CreateAccount_UnderFunded()
        {
            var access = new AccountAccess(new Accounts_Mock());
            var result = await access.CreateAccount(new CreateAccountRequest
            {
                UserName = "test tester",
                StartingFunds = 50m
            });

            Assert.IsNotNull(result);
            Assert.IsFalse(result.TransactionSucceeded);
        }

        [Test]
        public async Task Deposit_CanDeposit()
        {
            var access = new AccountAccess(new Accounts_Mock());

            var depositAmount = 200m;
                        
            var result = await access.CreateAccount(new CreateAccountRequest
            {
                UserName = "test tester",
                StartingFunds = 100m
            });

            var r = await access.DepositToAccount(new DepositRequest
            {
                AccountId = result.Account.Id,
                DepositAmount = depositAmount
            });

            Assert.IsNotNull(r);
            Assert.IsTrue(r.TransactionSucceeded);
            Assert.IsNotNull(r.Account);
            Assert.That((result.Account.Balance + depositAmount).Equals(r.Account.Balance));
        }

        [Test]
        public async Task Withdraw_CanWithdraw()
        {
            var access = new AccountAccess(new Accounts_Mock());

            var withdraw = 100m;
            
            var result = await access.CreateAccount(new CreateAccountRequest
            {
                UserName = "test tester",
                StartingFunds = 1000m
            });

            var r = await access.WithdrawFromAccount(new WithdrawRequest
            {
                AccountId = result.Account.Id,
                WithdrawAmount = withdraw
            });

            Assert.IsNotNull(r);
            Assert.IsTrue(r.TransactionSucceeded);
            Assert.IsNotNull(r.Account);
        }
    }
}