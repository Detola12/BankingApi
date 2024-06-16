using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace bankingapi.Models
{
    [Index("AccountNo", IsUnique = true)]
    [Index("Email", IsUnique = true)]
    [Index("PhoneNumber", IsUnique = true)]
    [Index("BVN", IsUnique = true)]
    public class Customer
    {
        [Key]
        public Guid Id {get; set;}
        [StringLength(30)]
        public string FirstName {get; set;} = string.Empty;
        [StringLength(30)]
        public string LastName {get; set;} = string.Empty;
        [StringLength(50)]
        public string Email {get; set;} = string.Empty;
        [StringLength(70)]
        public string Address {get; set;} = string.Empty;
        [StringLength(15)]
        public string PhoneNumber {get; set;} = string.Empty;
        [StringLength(15)]
        public string BVN {get; set;} = string.Empty;
        [EnumDataType(typeof(AccountType))]
        public AccountType AccountType {get; set;}
        public DateTime DateOfBirth {get; set;}
        public decimal AccountBalance {get; set;}
        [AllowNull]
        public string? AccountNo {get; set;} = null;
        public DateTime RegisteredOn {get; set;} = DateTime.Now;
        public DateTime UpdatedOn {get; set;} = DateTime.Now;


    }
    
}