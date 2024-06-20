using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankingapi.Dtos.Transaction;
using bankingapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace bankingapi.Controllers
{
    [ApiController]
    [Route("api")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;
        public TransactionController(ITransactionService service)
        {
            _service = service;
        }
        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransferDto transferDto){
            try{
                if(!_service.CheckBalance(transferDto.SenderId, transferDto.Amount)){
                    return BadRequest(new{Status = "Failed", Message = "Insuffient Balance"});
                }
            
                var transaction = await _service.MakeTransfer(transferDto);
                return Ok(new {Status = "Success", data = transaction});
            }
            catch(Exception ex){
                return BadRequest(new{Status = "Failed", Message = ex.Message});
            }
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositDto depositDto){
            try{
                var transaction = await _service.MakeDeposit(depositDto);
                return Ok(new {Status = "Success", data = transaction});
            }
            catch(Exception ex){
                return BadRequest(new{Status = "Failed", Message = ex.Message});
            }
        }
        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawDto withdrawDto){
            try{
                if(!_service.CheckBalance(withdrawDto.CustomerId, withdrawDto.Amount)){
                    return BadRequest(new{Status = "Failed", Message = "Insuffient Balance"});
                }
                var transaction = await _service.MakeWithdrawal(withdrawDto);
                return Ok(new {Status = "Success", data = transaction});
            }
            catch(Exception ex){
                return BadRequest(new{Status = "Failed", Message = ex.Message});
            }
        }
    }
}