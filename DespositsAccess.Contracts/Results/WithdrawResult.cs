using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsAccess.Contracts.Results
{
    public class WithdrawResult : AccountResultBase
    {
        public decimal WithdrawnAmount { get; set; }
    }
}
