using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Solution
{
    public class Customer
    {
        public CheckingAccount Checking { get; }

        public SavingAccount Saving { get; }

        private string name;

        public Customer(string name)
        {
            this.name = name;
            this.Checking = new CheckingAccount();
            this.Saving = new SavingAccount();
        }
    }
}
