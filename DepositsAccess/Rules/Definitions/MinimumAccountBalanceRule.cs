using Banking.Common.Rules;
using AccountsAccess.Contracts.Requests;

namespace AccountsAccess.Service.Rules.Definitions
{
    internal class MinimumAccountBalanceRule : IRuleDefinition
    {
        public RuleResult Execute(RuleContext source)
        {
            var context = source as TransactionRuleContext;

            if (context?.Request is not WithdrawRequest request)
            {
                return new RuleResult(false, "request is null");
            }

            var remainingBalance = context?.UserAccount?.Balance - request?.WithdrawAmount;

            if (remainingBalance <= Config.MinimumAccountBalance)
            {
                return new RuleResult
                {
                    Success = false,
                    Message = $"Insufficient funds. Account balance cannot go below {Config.MinimumAccountBalance}"
                };
            }

            return new RuleResult
            {
                Success = true,
                Message = "success"
            };
        }
    }
}
