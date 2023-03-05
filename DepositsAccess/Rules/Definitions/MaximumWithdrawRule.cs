using Banking.Common.Rules;
using AccountsAccess.Contracts.Requests;

namespace AccountsAccess.Service.Rules.Definitions
{
    internal class MaximumWithdrawRule : IRuleDefinition
    {
        public RuleResult Execute(RuleContext source)
        {
            var context = source as TransactionRuleContext;

            if (context?.Request is not WithdrawRequest request)
            {
                return new RuleResult(false, "request is null");
            }

            var maximumWithdrawAmount = context?.UserAccount.Balance * Config.MaximumWithdrawPercent;

            if (request.WithdrawAmount >= maximumWithdrawAmount)
            {
                return new RuleResult
                {
                    Success = false,
                    Message = $"Withdraw request of {request?.WithdrawAmount} was too large." +
                    $"Must not exceed {Config.MaximumWithdrawPercent:P1} of current funds"
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
