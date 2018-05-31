using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Solution
{
    public class SavingAccount : Account
    {
        public const double InterestRate = 0.03;
        public const double WithdrawPenalty = 10.0;

        public override TransactionResult deposit(Transaction transaction)
        {
            transaction.Amount = (transaction.Amount + (transaction.Amount * InterestRate));
            Console.WriteLine();
            return base.deposit(transaction);
        }

        public override TransactionResult withdraw(Transaction transaction)
        {
            transaction.Amount = (transaction.Amount+ WithdrawPenalty);
                Console.WriteLine();
                return base.withdraw(transaction);
        }
    }
}
