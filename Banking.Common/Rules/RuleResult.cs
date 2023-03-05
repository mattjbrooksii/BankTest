using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Common.Rules
{
    public class RuleResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public RuleResult() { }

        public RuleResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
