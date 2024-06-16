using System.ComponentModel.DataAnnotations;

namespace bankingapi.Models
{
    public enum TransactionType
    {
        [Display(Name = "Withdrawal")]
        WithDraw,
        [Display(Name = "Transfer")]
        Transfer,
        [Display(Name = "Deposit")]
        Deposit
    }
}