using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankingapi.Data;
using bankingapi.Dtos.Customer;
using bankingapi.Mappers;
using bankingapi.Models;
using bankingapi.Services;
using Microsoft.EntityFrameworkCore;

namespace bankingapi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ICustomerService service;
        private readonly BContext _context;
        public CustomerRepository(BContext context, ICustomerService service)
        {
            _context = context;
            this.service = service;
        }

        // public async void AssignAccountNumber(string email)
        // {
        //     var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Email == email);
        //     customer.AccountNo = service.GenerateAccountNumber();
        //     await _context.SaveChangesAsync();
            
        // }

        public async Task<CustomerDto> CreateCustomer(CreateCustomerDto customerDto)
        {
            var customer = customerDto.FromCreateToCustomerModel();
            customer.AccountNo = service.GenerateAccountNumber();
            Console.WriteLine(customer.AccountNo);
            Console.WriteLine("nkdkandaknads");
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer.ToCustomerDto();
        }

        public async Task<CustomerDto?> DeleteCustomer(Guid id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if(customer == null){
                return null;
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer.ToCustomerDto();
        }

        public async Task<List<string>> GetAccountAllAccountNumber()
        {
            var accountNumbers = await _context.Customers.Select(x => x.AccountNo).ToListAsync();
            return accountNumbers;
        }

        public async Task<List<CustomerDto>> GetAllCustomersAsync()
        {
            return await _context.Customers.Select(x => x.ToCustomerDto()).ToListAsync();
        }

        public async Task<CustomerDto?> GetCustomerByIdAsync(Guid id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if(customer == null){
                return null;
            }
            return customer.ToCustomerDto();
        }

        public async Task<CustomerDto?> UpdateCustomer(Guid id, UpdateCustomerDto customerDto)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if(customer == null){
                return null;
            }
            customer.FirstName = customerDto.FirstName;
            customer.LastName = customerDto.LastName;
            customer.Address = customerDto.Address;
            customer.PhoneNumber = customerDto.PhoneNumber;
            customer.DateOfBirth = customerDto.DateOfBirth;
            customer.BVN = customerDto.BVN;
            customer.UpdatedOn = DateTime.Now;

            await _context.SaveChangesAsync();
            return customer.ToCustomerDto();
        }
    }
}