using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Solution
{
    public class CheckingAccount : Account
    {
        public const double DailyCap = 300.0;
        public static double DailySpent = 0;
        public override TransactionResult withdraw(Transaction transaction)
        {
            Transaction tran = transaction;
            if ((tran.Amount + DailySpent) > DailyCap)
            {
                Console.WriteLine("\nYou exceed the daily limit. Maximum is $300");
                return TransactionResult.EXCEED_DAILY_AMOUNT;
            }
            else
            {
                DailySpent += tran.Amount;
                return base.withdraw(transaction);
            }
        }
    }
}
