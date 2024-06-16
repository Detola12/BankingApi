using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankingapi.Services
{
    public interface ICustomerService
    {
        public string GenerateAccountNumber();
        public Task<decimal> Transfer(decimal amount);
        public Task<decimal> Withdraw(decimal amount);
        public Task<decimal> Deposit(decimal amount);
        public Task<decimal> CheckBalance();
    }
}