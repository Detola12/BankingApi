using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankingapi.Dtos.Transaction
{
    public class WithdrawDto
    {
        public Guid CustomerId{ get; set; }
        public string AccountNo{ get; set; } = string.Empty;
        public decimal Amount { get; set; }   
    }
}