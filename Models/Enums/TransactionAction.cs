using System.ComponentModel.DataAnnotations;

namespace bankingapi.Models.Enums
{
    public enum TransactionAction
    {
        [Display(Name = "Withdrawal")]
        WithDraw,
        [Display(Name = "Transfer")]
        Transfer,
        [Display(Name = "Deposit")]
        Deposit
    }
}