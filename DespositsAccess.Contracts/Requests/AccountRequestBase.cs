using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsAccess.Contracts.Requests
{
    public abstract class AccountRequestBase
    {
        public string AccountId { get; set; }
    }
}
