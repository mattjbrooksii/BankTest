using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsAccess.Contracts.Requests
{
    public class WithdrawRequest : AccountRequestBase
    {
        public decimal WithdrawAmount { get; set; }
    }
}
