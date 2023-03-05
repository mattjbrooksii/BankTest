using AccountsAccess.Contracts.Requests;
using AccountsAccess.Service.Implementation;
using AccountsAccess.Service.Rules;
using AccountsAccess.Service.Rules.Definitions;
using Banking.Common.Rules;
using StorageImplementation.Accounts;

namespace BankingTests
{
    internal class RulesTests
    {

        [Test]
        public async Task MaxDepositRuleTest_Pass()
        {
            var access = new AccountAccess(new Accounts_Mock());
            var result = await access.CreateAccount(new CreateAccountRequest
            {
                StartingFunds = 100m,
                UserName = "Test Tester"
            });

            var request = new DepositRequest
            {
                AccountId = result.Account.Id,
                DepositAmount = 500m,
            };

            var ruleUtility = new TransactionRulesExecutor();

            var results = ruleUtility.ExecuteRules(new List<IRuleDefinition>
            {
                new MaxDepositRule()
            },
            new TransactionRuleContext
            {
                Request = request,
                UserAccount = result.Account
            });

            var ruleResult = results.First();

            Assert.IsNotNull(ruleResult);
            Assert.IsTrue(ruleResult.Success);
        }

        [Test]
        public async Task MaxDepositRuleTest_Fail()
        {
            var access = new AccountAccess(new Accounts_Mock());
            var result = await access.CreateAccount(new CreateAccountRequest
            {
                StartingFunds = 100m,
                UserName = "Test Tester"
            });

            var request = new DepositRequest
            {
                AccountId = result.Account.Id,
                DepositAmount = 10000m,
            };

            var ruleUtility = new TransactionRulesExecutor();

            var results = ruleUtility.ExecuteRules(new List<IRuleDefinition>
            {
                new MaxDepositRule()
            },
            new TransactionRuleContext
            {
                Request = request,
                UserAccount = result.Account
            });

            var ruleResult = results.First();

            Assert.IsNotNull(ruleResult);
            Assert.IsFalse(ruleResult.Success);
        }

        [Test]
        public async Task MaxWithdrawRuleTest_Pass()
        {
            var access = new AccountAccess(new Accounts_Mock());
            var result = await access.CreateAccount(new CreateAccountRequest
            {
                StartingFunds = 1000m,
                UserName = "Test Tester"
            });

            var request = new WithdrawRequest
            {
                AccountId = result.Account.Id,
                WithdrawAmount = 500m,
            };

            var ruleUtility = new TransactionRulesExecutor();

            var results = ruleUtility.ExecuteRules(new List<IRuleDefinition>
            {
                new MaximumWithdrawRule()
            },
            new TransactionRuleContext
            {
                Request = request,
                UserAccount = result.Account
            });

            var ruleResult = results.First();

            Assert.IsNotNull(ruleResult);
            Assert.IsTrue(ruleResult.Success);
        }

        [Test]
        public async Task MaxWithdrawRuleTest_Fail()
        {
            var access = new AccountAccess(new Accounts_Mock());
            var result = await access.CreateAccount(new CreateAccountRequest
            {
                StartingFunds = 500m,
                UserName = "Test Tester"
            });

            var request = new WithdrawRequest
            {
                AccountId = result.Account.Id,
                WithdrawAmount = 400m,
            };

            var ruleUtility = new TransactionRulesExecutor();

            var results = ruleUtility.ExecuteRules(new List<IRuleDefinition>
            {
                new MaximumWithdrawRule()
            },
            new TransactionRuleContext
            {
                Request = request,
                UserAccount = result.Account
            });

            var ruleResult = results.First();

            Assert.IsNotNull(ruleResult);
            Assert.IsFalse(ruleResult.Success);
        }

        [Test]
        public async Task MinimumAccountBalanceRuleTest_Pass()
        {
            var access = new AccountAccess(new Accounts_Mock());
            var result = await access.CreateAccount(new CreateAccountRequest
            {
                StartingFunds = 600m,
                UserName = "Test Tester"
            });

            var request = new WithdrawRequest
            {
                AccountId = result.Account.Id,
                WithdrawAmount = 500m,
            };

            var ruleUtility = new TransactionRulesExecutor();

            var results = ruleUtility.ExecuteRules(new List<IRuleDefinition>
            {
                new MinimumAccountBalanceRule()
            },
            new TransactionRuleContext
            {
                Request = request,
                UserAccount = result.Account
            });

            var ruleResult = results.First();

            Assert.IsNotNull(ruleResult);
            Assert.IsTrue(ruleResult.Success);
        }

        [Test]
        public async Task MinimumAccountBalanceRuleTest_Fail()
        {
            var access = new AccountAccess(new Accounts_Mock());
            var result = await access.CreateAccount(new CreateAccountRequest
            {
                StartingFunds = 100m,
                UserName = "Test Tester"
            });

            var request = new WithdrawRequest
            {
                AccountId = result.Account.Id,
                WithdrawAmount = 500m,
            };

            var ruleUtility = new TransactionRulesExecutor();

            var results = ruleUtility.ExecuteRules(new List<IRuleDefinition>
            {
                new MinimumAccountBalanceRule()
            },
            new TransactionRuleContext
            {
                Request = request,
                UserAccount = result.Account
            });

            var ruleResult = results.First();

            Assert.IsNotNull(ruleResult);
            Assert.IsFalse(ruleResult.Success);
        }
    }
}
