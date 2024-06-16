using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankingapi.Dtos.Customer;
using bankingapi.Models;

namespace bankingapi.Repository
{
    public interface ICustomerRepository
    {
        public Task<List<CustomerDto>> GetAllCustomersAsync();
        public Task<CustomerDto?> GetCustomerByIdAsync(Guid id);
        public Task<CustomerDto?> DeleteCustomer(Guid id);
        public Task<CustomerDto> CreateCustomer(CreateCustomerDto customerDto);
        public Task<CustomerDto?> UpdateCustomer(Guid id, UpdateCustomerDto customerDto);
        public Task<List<string>> GetAccountAllAccountNumber();

    }
}