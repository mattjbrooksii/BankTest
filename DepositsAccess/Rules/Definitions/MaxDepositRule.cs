using Banking.Common.Rules;
using AccountsAccess.Contracts.Requests;

namespace AccountsAccess.Service.Rules.Definitions
{
    internal class MaxDepositRule : IRuleDefinition
    {
        public RuleResult Execute(RuleContext source)
        {
            var context = source as TransactionRuleContext;

            if (context?.Request is not DepositRequest request)
            {
                return new RuleResult(false, "request is null");
            }

            if (request.DepositAmount >= Config.MaxDepositAmount)
            {
                return new RuleResult
                {
                    Success = false,
                    Message = $"Deposit amount of {request.DepositAmount} was too large." +
                    $" Must remain below {Config.MaxDepositAmount}"
                };
            }

            return new RuleResult(true, "success");
        }
    }
}
