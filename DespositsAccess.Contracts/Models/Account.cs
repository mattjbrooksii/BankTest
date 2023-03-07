using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsAccess.Contracts.Models
{
    public class Account
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public decimal Balance { get; set; }

    }
}
