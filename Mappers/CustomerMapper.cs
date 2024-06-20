using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankingapi.Dtos.Customer;
using bankingapi.Models;
using Microsoft.OpenApi.Extensions;

namespace bankingapi.Mappers
{
    public static class CustomerMapper
    {
        public static Customer FromCreateToCustomerModel(this CreateCustomerDto customerDto){
            return new Customer{
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Email = customerDto.Email,
                DateOfBirth = customerDto.DateOfBirth,
                Address = customerDto.Address,
                PhoneNumber = customerDto.PhoneNumber,
                BVN = customerDto.BVN,
                AccountType = customerDto.AccountType,
            };
        }
        public static Customer FromUpdateToCustomerModel(this UpdateCustomerDto customerDto){
            return new Customer{
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Email = customerDto.Email,
                DateOfBirth = customerDto.DateOfBirth,
                Address = customerDto.Address,
                PhoneNumber = customerDto.PhoneNumber,
                BVN = customerDto.BVN,  
            };
        }

        public static CustomerDto ToCustomerDto(this Customer customer){
            return new CustomerDto{
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                DateOfBirth = customer.DateOfBirth,
                Address = customer.Address,
                PhoneNumber = customer.PhoneNumber,
                BVN = customer.BVN,
                AccountNo = customer.AccountNo,
                AccountBalance = customer.AccountBalance,
                AccountType = customer.AccountType.GetDisplayName(),
            };
        }
    }
}