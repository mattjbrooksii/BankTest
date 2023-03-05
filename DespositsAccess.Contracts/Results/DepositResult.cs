using AccountsAccess.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsAccess.Contracts.Results
{
    public class DepositResult : AccountResultBase
    {
        public decimal AmountDeposited { get; set; }
    }
}
