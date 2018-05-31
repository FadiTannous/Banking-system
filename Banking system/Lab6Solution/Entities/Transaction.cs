using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Solution
{
    public class Transaction
    {
        public string Memo { get; set; }
        public double Amount { get; set; }   
        public TransactionType Type { get; }
        public DateTime TransactionDate { get; }
        public Account Account { get; }

        public Transaction(Account account, double amount, TransactionType type)
        {
            Account = account;
            Amount = amount;
            Type = type;
            Memo = type.ToString();
            TransactionDate = DateTime.Today;
        }
    }
}
