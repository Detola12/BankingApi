using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankingapi.Dtos.Customer;
using bankingapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace bankingapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository repository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            repository = customerRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto customerDto){
            try{
                var customer = await repository.CreateCustomer(customerDto);
                return Ok(new{ Status = "Success", Message = "Customer Successfully Created", Response = customer });
            }
            catch(Exception ex){
                return BadRequest(new {Status = "Failed", Message = ex.Message});
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers(){
            var customers = await repository.GetAllCustomersAsync();
            return Ok(new{ Status = "Success",Response = customers});
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id){
            var customer = repository.GetCustomerByIdAsync(id);
            if(customer==null){
                return NotFound(new{ Status = "Failed", Message = "Customer Not Found"});
            }
            return Ok(new{ Status = "Success", Response = customer});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] Guid id, [FromBody] UpdateCustomerDto customerDto){
            var customer = await repository.UpdateCustomer(id, customerDto);
            if(customer == null){
                return NotFound(new{ Status = "Failed", Message = "Customer Not Found"});
            }
            return Ok(new{ Status = "Updated", Message = "Updated Successfully", Response = customer});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id){
            var customer = await repository.DeleteCustomer(id);
            if(customer == null){
                return NotFound(new{ Status = "Failed", Message = "Customer Not Found"});
            }
            return Ok(new{ Status = "Deleted", Message = "Deleted Successfully", Response = customer});
        }

        // [HttpPost("assignAccount/{id}")]
        // public async Task<IActionResult> AssignCustomer([FromRoute] Guid id){
        //     var customer = await repository.AssignAccountNumber(id);
        //     if(customer == null){
        //         return NotFound(new{ Status = "Failed", Message = "Customer Not Found"});
        //     }
        //     return Ok(new{ Status = "Deleted", Message = "Deleted Successfully", Data = customer});
        // }
    }
}