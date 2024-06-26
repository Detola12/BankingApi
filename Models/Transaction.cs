using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using bankingapi.Models.Enums;

namespace bankingapi.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        public Guid Id{ get; set; }
        public Guid SenderId{ get; set; }
        public string AccountNo {get; set; } = string.Empty;
        [Range(0,2)]
        public TransactionType TransactionType{ get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("SenderId")]
        public Customer? Sender{ get; set; }
        public DateTime AddedOn {get; set;} = DateTime.UtcNow;
        
        
    }
}