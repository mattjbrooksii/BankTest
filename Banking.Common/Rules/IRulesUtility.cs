using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Common.Rules
{
    public interface IRulesUtility
    {
        IEnumerable<RuleResult> ExecuteRules(IEnumerable<IRuleDefinition> rules, RuleContext context);
    }
}
