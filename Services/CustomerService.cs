using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankingapi.Services
{
    public class CustomerService : ICustomerService
    {
        private static readonly Random random = new Random();

        public Task<decimal> CheckBalance()
        {
            throw new NotImplementedException();
        }

        public Task<decimal> Deposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public string GenerateAccountNumber()
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int length = 8;
            string accountNo = "";

            for(int i = 0; i < length; i++){
                accountNo += characters[random.Next(characters.Length - 1)];
            }

            return accountNo; 
        }

        public Task<decimal> Transfer(decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> Withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}