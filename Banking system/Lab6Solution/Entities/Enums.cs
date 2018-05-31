using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Solution
{
   public enum TransactionResult
    {
       SUCCESS,
       INSUFFICIENT_FUND,
       EXCEED_DAILY_AMOUNT
   }

    public enum TransactionType
    {
        DEPOSIT,
        WITHDRAW,
        TRANSFER
    }
}
