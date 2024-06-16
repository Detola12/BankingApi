using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using bankingapi.Models;

namespace bankingapi.Dtos.Customer
{
    public class CreateCustomerDto
    {
        public string FirstName {get; set;} = string.Empty;
        [MaxLength(30)]
        public string LastName {get; set;} = string.Empty;
        [MaxLength(50)]
        [EmailAddress]
        public string Email {get; set;} = string.Empty;
        [MaxLength(70)]
        public string Address {get; set;} = string.Empty;
        [MaxLength(15)]
        public string PhoneNumber {get; set;} = string.Empty;
        [MaxLength(15)]
        public string BVN {get; set;} = string.Empty;
        [EnumDataType(typeof(AccountType))]
        public AccountType AccountType {get; set;}
        public DateTime DateOfBirth {get; set;}
    }
}