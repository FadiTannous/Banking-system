using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Solution
{
    public class Account
    {
        public double Balance { get; protected set; }

        public ArrayList TransactionHistories { get; }

        public Account()
        {
            Balance = 0.0;
            TransactionHistories = new ArrayList();
        }
        public virtual TransactionResult deposit(Transaction tran)
        {
            this.Balance += tran.Amount;
            Console.WriteLine();
            //Console.Write("Deposit complete, account current balance: $"+Balance + "\n");
            TransactionHistories.Add(tran);
            Console.WriteLine();
            Console.WriteLine("Deposit success!");
            Console.WriteLine();
            return TransactionResult.SUCCESS;
        }

        public virtual TransactionResult initializeAcc(Transaction tran)
        {
            this.Balance = tran.Amount;
            return TransactionResult.SUCCESS;
        }
        public virtual TransactionResult withdraw(Transaction tran)
        {
            if (this.Balance < tran.Amount)
            {
                Console.WriteLine("\nYou cannot withdraw more money than you have!");
                return TransactionResult.INSUFFICIENT_FUND;
            }
            else
            {
                this.Balance -= tran.Amount;
                Console.WriteLine();
                //Console.Write("Withdraw complete, account current balance: $" + Balance + "\n");
                TransactionHistories.Add(tran);
                Console.WriteLine();
                Console.WriteLine("Withdraw success!");
                Console.WriteLine();
                return TransactionResult.SUCCESS;
            }
        }
    }
}
