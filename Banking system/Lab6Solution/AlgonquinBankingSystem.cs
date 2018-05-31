using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab6Solution
{
    class AlgonquinBankingSystem
    {
        public static string tempName;
        public static string tempCheck;
        public static string tempSave;
        public static double balCheck = -1;
        public static double balSave = -1;
        #region Main
        static void Main(string[] args)
        {
            string name = "";
            Customer customer;

            bool chexck = checkCustomer();


            if (chexck)
            {
                name = tempName;
                string checkbalance = tempCheck;
                string checksave = tempSave;
                balCheck = double.Parse(tempCheck);
                balSave = double.Parse(tempSave);
                Console.Write("Hello " + name);
                customer = new Customer(name);
                deposit(customer);
                showBalance(customer);
            }
            else
            {
                System.Console.WriteLine("Welcome to Algonquin Banking System!");
                System.Console.WriteLine();
                System.Console.Write("Enter Customer Name: ");
                name = System.Console.ReadLine();
                customer = new Customer(name);
            }
            
            bool finished = false;
            while (!finished)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Select  one of the following activities: ");
                System.Console.WriteLine();

                System.Console.WriteLine(" 1. Deposit ...");
                System.Console.WriteLine(" 2. Withdraw ...");
                System.Console.WriteLine(" 3. Transfer ...");
                System.Console.WriteLine(" 4. Account Activity Enquiry ...");
                System.Console.WriteLine(" 5. Balance Enquiry ...");
                System.Console.WriteLine(" 6. Exit");

                System.Console.WriteLine();
                System.Console.Write(" Enter your selection (1 to 6): ");
                string selectionInput = System.Console.ReadLine();

                int selection;
                if (!int.TryParse(selectionInput, out selection))
                {
                    selection = -1;
                }

                switch (selection)
                {
                    case 1:
                        deposit(customer);
                        break;
                    case 2:
                        withdraw(customer);
                        break;
                    case 3:
                        transfer(customer);
                        break;
                    case 4:
                        acountActivity(customer);
                        break;
                    case 5:
                        showBalance(customer);
                        break;
                    case 6:
                        saveInfo(customer, name);
                        finished = true;
                        break;
                    default:
                        System.Console.WriteLine();
                        System.Console.WriteLine("Invalid selection! Enter 1 - 6 only!");
                        break;
                }
            }
            System.Console.WriteLine();
            System.Console.WriteLine("Thank you for using Algonquin Banking System!");
            System.Console.ReadLine();
        }
        #endregion
        #region Helpers

        private static void deposit(Customer customer)
        {
            if (balCheck != -1 && balSave != -1)
            {
                Account acc2 = new Account();
                acc2 = customer.Checking;
                Transaction trans2 = new Transaction(acc2, balCheck, TransactionType.DEPOSIT);
                acc2.initializeAcc(trans2);

                Account acc3 = new Account();
                acc3 = customer.Saving;
                Transaction trans3 = new Transaction(acc3, balSave, TransactionType.DEPOSIT);
                acc3.initializeAcc(trans3);

                balCheck = -1;
                balSave = -1;
            }
            else
            {
                System.Console.WriteLine();
                System.Console.Write(" Select account (1 - Checking Account, 2 - Saving Account): ");
                string checkOrSave = Console.ReadLine();
                int selectedAccount=0;

                //ENSURE 1 OR 2 IS SELECTED
                while (selectedAccount < 1 || selectedAccount > 2)
                {
                    if (!int.TryParse(checkOrSave, out selectedAccount))
                    {
                        System.Console.WriteLine();
                        System.Console.WriteLine(" INVALID INPUT - Select account (1 - Checking Account, 2 - Saving Account): ");
                        checkOrSave = Console.ReadLine();
                    }
                    else { }
                    if (selectedAccount < 1 || selectedAccount > 2)
                    {
                        System.Console.WriteLine();
                        System.Console.WriteLine(" INVALID INPUT - Select account (1 - Checking Account, 2 - Saving Account): ");
                        checkOrSave = Console.ReadLine();
                    }
                    else
                    {
                        break;
                    }
                }
                System.Console.Write(" Enter Amount: ");
                string amtChecker = Console.ReadLine();
                double amount = 0;
                while (amount< 1)
                {
                    if (!double.TryParse(amtChecker, out amount))
                    {
                        System.Console.WriteLine();
                        System.Console.WriteLine(" INVALID INPUT - Enter Amount:");
                        amtChecker = Console.ReadLine();
                    }
                    else
                    {
                        break;
                    }
                }
                Account acc = new Account();
                if (selectedAccount == 1)
                {
                    acc = customer.Checking;
                }
                else
                {
                    acc = customer.Saving;
                }
                Transaction trans = new Transaction(acc, amount, TransactionType.DEPOSIT);
                acc.deposit(trans);
            }
        }

        private static void withdraw(Customer customer)
        {
            System.Console.WriteLine();
            System.Console.Write(" Select account (1 - Checking Account, 2 - Saving Account): ");
            /*int selectedAccount = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine();
            System.Console.Write(" Enter Amount: ");
            double amount = double.Parse(System.Console.ReadLine());
            */
            string checkOrSave = Console.ReadLine();
            int selectedAccount = 0;

            //ENSURE 1 OR 2 IS SELECTED
            while (selectedAccount < 1 || selectedAccount > 2)
            {
                if (!int.TryParse(checkOrSave, out selectedAccount))
                {
                    //int selectedAccount = int.Parse(System.Console.ReadLine());
                    System.Console.WriteLine();
                    System.Console.WriteLine(" INVALID INPUT - Select account (1 - Checking Account, 2 - Saving Account): ");
                    checkOrSave = Console.ReadLine();
                }
                else { }
                if (selectedAccount < 1 || selectedAccount > 2)
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine(" INVALID INPUT - Select account (1 - Checking Account, 2 - Saving Account): ");
                    checkOrSave = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            System.Console.Write(" Enter Amount: ");
            string amtChecker = Console.ReadLine();
            double amount = 0;
            while (amount < 1)
            {
                if (!double.TryParse(amtChecker, out amount))
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine(" INVALID INPUT - Enter Amount:");
                    amtChecker = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            Account acc = new Account();
            if (selectedAccount == 1)
            {
                acc = customer.Checking;
            }
            else
            {
                acc = customer.Saving;
            }
            Transaction trans = new Transaction(acc, amount, TransactionType.WITHDRAW);
            acc.withdraw(trans);
        }

        private static void transfer(Customer customer)
        {
            System.Console.WriteLine();
            System.Console.Write(" Select accounts (1 - from Checking to Saving; 2 - from Saving to Checking): ");
            int selection = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine();
            System.Console.Write(" Enter Amount: ");
            double amount = double.Parse(System.Console.ReadLine());
            Account acc = new Account();
            Account acc2 = new Account();
            if (selection == 1)
            {
                acc = customer.Checking;
                acc2 = customer.Saving;
            }
            else
            {
                acc = customer.Saving;
                acc2 = customer.Checking;
            }
            Transaction trans = new Transaction(acc, amount, TransactionType.DEPOSIT);
            Transaction trans2 = new Transaction(acc, amount, TransactionType.DEPOSIT);
            if (selection == 1)
            {
                if(acc.withdraw(trans) == TransactionResult.SUCCESS)
                acc2.deposit(trans2);
            }
            else
            {
                if(acc.withdraw(trans) == TransactionResult.SUCCESS)
                acc2.deposit(trans2);
            }
        }

        private static void acountActivity(Customer customer)
        {
            System.Console.WriteLine(" Checking Account:");
            System.Console.WriteLine();
            System.Console.WriteLine("    Amount  \t\t Date \t\t\t Activity");
            System.Console.WriteLine("    ------ \t\t ---- \t\t\t  --------");
            Account account = customer.Checking;
            foreach (Transaction transaction in account.TransactionHistories)
            {
                System.Console.WriteLine("    ${0} \t\t {1} \t\t {2}", transaction.Amount, transaction.TransactionDate.ToShortDateString(), transaction.Memo );
            }
            System.Console.WriteLine();
            System.Console.WriteLine(" Saving Account:");
            System.Console.WriteLine();
            System.Console.WriteLine("    Amount  \t\t Date \t\t\t Activity");
            System.Console.WriteLine("    ------ \t\t ---- \t\t\t --------");
            account = customer.Saving;
            foreach (Transaction transaction in account.TransactionHistories)
            {
                System.Console.WriteLine("    ${0} \t\t {1} \t\t {2}", transaction.Amount, transaction.TransactionDate.ToShortDateString(), transaction.Memo);
            }
        }

        private static void showBalance(Customer customer)
        {
            System.Console.WriteLine();
            System.Console.WriteLine(" Current balance:");
            System.Console.WriteLine("    Account \t\t\t\t  Balance");
            System.Console.WriteLine("    -------- \t\t\t\t  ------");
            System.Console.WriteLine("    Checking \t\t\t\t  ${0}", customer.Checking.Balance);
            System.Console.WriteLine("    Saving \t\t\t\t  ${0}", customer.Saving.Balance);

        }
        #endregion

        public static bool checkCustomer() {

            string line;
            StreamReader sr = null;
            string[] info = new string[4];
            int i = 0;

            try
            {
                    FileStream aFile = new FileStream("../../bank/customer.txt", FileMode.Open);
                    sr = new StreamReader(aFile);
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        line = sr.ReadLine();
                        info[i] = line;
                        i++;
                    }  
            }
            catch (IOException e)
            {
                return false;
                //Console.WriteLine("An IO exception has been thrown!");
                //Console.WriteLine(e);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }

            tempName = info[0];
            tempCheck = info[1];
            tempSave = info[2];

            return true;
        }

        public static void saveInfo(Customer customer, string name)
        {
            if (!File.Exists("../../bank/customer.txt"))
            {
                var myFile = File.Create("../../bank/customer.txt");
                myFile.Close();
            }
            FileStream fs = new FileStream("../../bank/customer.txt", FileMode.Truncate, FileAccess.Write);
            fs.Close();
            StreamWriter sw = null;
            try
            {

                FileStream aFile = new FileStream("../../bank/customer.txt", FileMode.OpenOrCreate);
                sw = new StreamWriter(aFile);

                // Write data to file.
                sw.WriteLine("Customer info:");
                sw.WriteLine(name);
                sw.WriteLine(customer.Checking.Balance);
                sw.WriteLine(customer.Saving.Balance);
            }
            catch (IOException e)
            {
                Console.WriteLine("An IO exception has been thrown!");
                Console.WriteLine(e.ToString());
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }

    }
}
