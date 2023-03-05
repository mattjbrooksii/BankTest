using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsAccess.Contracts.Requests
{
    public class GetUserAccountsRequest
    {
        public string UserId { get; set; }
        public string UserFullName { get; set; }
    }
}
