using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bankingapi.Dtos.Transaction
{
    public class TransferDto
    {
        [Required]
        public Guid SenderId{ get; set; }
        [Required]
        public string? AccountNo {get; set; }
        [Required]
        public decimal Amount { get; set; }   
    }
}