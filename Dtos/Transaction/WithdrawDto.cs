using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankingapi.Dtos.Transaction
{
    public class WithdrawDto
    {
        public Guid Id{ get; set; }
        public Guid CustomerId{ get; set; }
        public decimal Amount { get; set; }   
    }
}