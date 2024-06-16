using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankingapi.Dtos.Transaction;

namespace bankingapi.Services
{
    public interface ITransactionService
    {
        public Task<TransferDto?> MakeTransfer(TransferDto transferDto);
        public Task<WithdrawDto?> MakeWithdrawal(WithdrawDto withdrawDto);
        public Task<DepositDto?> MakeDeposit(DepositDto depositDto);
        public bool CheckBalance(Guid id, decimal amount);
    }
}