using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsAccess.Service
{
    internal static class Config
    {
        public static decimal MaxDepositAmount => 10000m;
        public static decimal MinimumAccountBalance => 100m;
        public static decimal MaximumWithdrawPercent => .90m;
    }
}
