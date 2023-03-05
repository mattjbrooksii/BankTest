using AccountsAccess.Contracts.Requests;
using Banking.Common.Rules;

namespace AccountsAccess.Service.Rules.Definitions
{
    internal class MinimumFundingRule : IRuleDefinition
    {
        public RuleResult Execute(RuleContext source)
        {
            var context = source as TransactionRuleContext;

            if (context?.Request is not CreateAccountRequest request)
            {
                return new RuleResult(false, "request is null");
            }

            if (request.StartingFunds < Config.MinimumAccountBalance)
            {
                return new RuleResult
                {
                    Success = false,
                    Message = $"Account must be funded with at least {Config.MinimumAccountBalance} at all times."
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
