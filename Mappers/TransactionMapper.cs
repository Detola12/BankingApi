using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankingapi.Dtos.Transaction;
using bankingapi.Models;

namespace bankingapi.Mappers
{
    public static class TransactionMapper
    {
        public static Transaction ToTransactionModelFromTransfer(this TransferDto transferDto){
            return new Transaction{
                SenderId = transferDto.SenderId,
                AccountNo = transferDto.AccountNo,
                Amount = transferDto.Amount,
                TransactionType = TransactionType.Transfer,
            };
        }

        public static Transaction ToTransactionModelFromWithdraw(this WithdrawDto withdrawDto){
            return new Transaction{
                SenderId = withdrawDto.CustomerId,
                AccountNo = withdrawDto.AccountNo,
                Amount = withdrawDto.Amount,
                TransactionType = TransactionType.WithDraw,
            };
        }
        public static Transaction ToTransactionModelFromDeposit(this DepositDto depositDto){
            return new Transaction{
                SenderId = depositDto.CustomerId,
                AccountNo = depositDto.AccountNo,
                Amount = depositDto.Amount,
                TransactionType = TransactionType.WithDraw,
            };
        }
    }
}