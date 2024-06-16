using System.ComponentModel.DataAnnotations;

namespace bankingapi.Models
{
    public enum AccountType
    {
        [Display(Name = "Savings Account")]
        Savings,
        [Display(Name = "Current Account")]
        Current
    }
}