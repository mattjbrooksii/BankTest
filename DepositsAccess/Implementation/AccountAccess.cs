using AccountsAccess.Contracts;
using AccountsAccess.Contracts.Models;
using AccountsAccess.Contracts.Requests;
using AccountsAccess.Contracts.Results;
using AccountsAccess.Service.Repository;
using AccountsAccess.Service.Rules;
using AccountsAccess.Service.Rules.Definitions;
using Banking.Common.Rules;

namespace AccountsAccess.Service.Implementation
{
    public class AccountAccess : IAccountsAccess
    {
        private readonly IAccountsRepository _accountStorage;
        private readonly IRulesUtility _rulesUtility;

        public AccountAccess(IAccountsRepository accountStorage)
        {
            _accountStorage = accountStorage;
            _rulesUtility = new TransactionRulesExecutor();
        }

        public async Task<CreateAccountResult> CreateAccount(CreateAccountRequest createRequest)
        {
            var rules = new List<IRuleDefinition>
            {
                new MinimumFundingRule()
            };

            var ruleResults = _rulesUtility.ExecuteRules(rules, new TransactionRuleContext
            {
                Request = createRequest
            });

            if (ruleResults.Any(r => !r.Success))
            {
                return new CreateAccountResult
                {
                    TransactionSucceeded = false,
                    Message = string.Join(',', ruleResults.Where(r => !r.Success).Select(s => s.Message))
                };
            }

            var account = await _accountStorage.SaveAccount(new Account
            {
                Balance = createRequest.StartingFunds,
                Id = Guid.NewGuid().ToString(),
                UserId = Guid.NewGuid().ToString(),
                UserFullName = createRequest.UserName
            });

            return new CreateAccountResult
            {
                Account = account,
                Message = "success",
                TransactionSucceeded = true
            };
        }

        public async Task<GetUserAccountsResult> GetAllAccountsForUser(GetUserAccountsRequest userAccountsRequest)
        {
            var accounts = await _accountStorage.GetAllAccounts(new GetAccountsParameters
            {
                UserId = userAccountsRequest.UserId,
                UserFullName = userAccountsRequest.UserFullName
            });

            return new GetUserAccountsResult
            {
                UserAccounts = accounts,
                UserFullName = userAccountsRequest.UserFullName,
                UserId = userAccountsRequest.UserId
            };
        }

        public async Task<DeleteAccountResult> DeleteAccount(DeleteAccountRequest deleteRequest)
        {
            await _accountStorage.DeleteAccount(deleteRequest.AccountId);

            return new DeleteAccountResult
            {
                TransactionSucceeded = true,
                Message = $"Delete account {deleteRequest.AccountId} completed"
            };
        }

        public async Task<DepositResult> DepositToAccount(DepositRequest depositRequest)
        {
            var rules = new List<IRuleDefinition>
            {
                new MaxDepositRule()
            };

            var ruleResults = _rulesUtility.ExecuteRules(rules, new TransactionRuleContext
            {
                Request = depositRequest
            });

            if (ruleResults.Any(r => !r.Success))
            {
                return new DepositResult
                {
                    AmountDeposited = 0,
                    TransactionSucceeded = false,
                    Message = string.Join(',', ruleResults.Where(r => !r.Success).Select(s => s.Message))
                };
            }

            var existingAccount = await _accountStorage.GetAccount(depositRequest.AccountId);

            if (existingAccount is null)
            {
                return new DepositResult
                {
                    AmountDeposited = 0,
                    TransactionSucceeded = false
                };
            }

            existingAccount.Balance += depositRequest.DepositAmount;
            var updatedAccount = await _accountStorage.SaveAccount(existingAccount);

            return new DepositResult
            {
                Account = updatedAccount,
                AmountDeposited = depositRequest.DepositAmount,
                Message = "success",
                TransactionSucceeded = true
            };
        }        

        public async Task<WithdrawResult> WithdrawFromAccount(WithdrawRequest withdrawRequest)
        {
            var account = await _accountStorage.GetAccount(withdrawRequest.AccountId);

            if (account is null)
            {
                return new WithdrawResult
                {
                    WithdrawnAmount = 0,
                    TransactionSucceeded = false
                };
            }

            var rules = new List<IRuleDefinition>
            {
                new MinimumAccountBalanceRule(),
                new MaximumWithdrawRule()
            };

            var ruleResults = _rulesUtility.ExecuteRules(rules, new TransactionRuleContext
            {
                Request = withdrawRequest,
                UserAccount = account
            });

            if (ruleResults.Any(r => !r.Success))
            {
                return new WithdrawResult
                {
                    WithdrawnAmount = 0,
                    TransactionSucceeded = false,
                    Message = string.Join(',', ruleResults.Where(r => !r.Success).Select(s => s.Message))
                };
            }

            account.Balance -= withdrawRequest.WithdrawAmount;
            var updatedAccount = await _accountStorage.SaveAccount(account);

            return new WithdrawResult
            {
                Account = updatedAccount,
                Message = "success",
                TransactionSucceeded = true,
                WithdrawnAmount = withdrawRequest.WithdrawAmount
            };
        }
    }
}
