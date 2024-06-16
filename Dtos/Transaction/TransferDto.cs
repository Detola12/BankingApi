using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankingapi.Dtos.Transaction
{
    public class TransferDto
    {
        public Guid SenderId{ get; set; }
        public Guid RecieverId {get; set; }
        public decimal Amount { get; set; }   
    }
}