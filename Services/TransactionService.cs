using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankingapi.Data;
using bankingapi.Dtos.Transaction;
using bankingapi.Mappers;
using Microsoft.EntityFrameworkCore;

namespace bankingapi.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly BContext _context;
        public TransactionService(BContext context)
        {
            _context = context;
        }

        public bool CheckBalance(Guid id, decimal amount)
        {
            var result = _context.Customers.FirstOrDefault(x => x.Id == id);
            if(result == null || result.AccountBalance < amount){
                return false;
            }
            return true;
        }

        public async Task<DepositDto?> MakeDeposit(DepositDto depositDto)
        {
            var deposit = depositDto.ToTransactionModelFromDeposit();
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == depositDto.CustomerId);
            if (customer == null){
                return null;
            }
            customer.AccountBalance += depositDto.Amount; 
            await _context.Transactions.AddAsync(deposit);
            await _context.SaveChangesAsync();
            return depositDto;
        }

        public async Task<TransferDto?> MakeTransfer(TransferDto transferDto)
        {
            var transfer = transferDto.ToTransactionModelFromTransfer();
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == transferDto.SenderId);
            var reciever = await _context.Customers.FirstOrDefaultAsync(y => y.Id == transferDto.RecieverId);
            if(customer == null || reciever == null){
                return null;
            }
            
            customer.AccountBalance -= transferDto.Amount;
            reciever.AccountBalance += transferDto.Amount;
            await _context.Transactions.AddAsync(transfer);
            await _context.SaveChangesAsync();
            return transferDto;
        }

            

        public async Task<WithdrawDto?> MakeWithdrawal(WithdrawDto withdrawDto)
        {
            var withdraw = withdrawDto.ToTransactionModelFromWithdraw();
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == withdrawDto.CustomerId);
            if (customer == null){
                return null;
            }
            customer.AccountBalance -= withdrawDto.Amount; 
            await _context.Transactions.AddAsync(withdraw);
            await _context.SaveChangesAsync();
            return withdrawDto;
        }
    }
}