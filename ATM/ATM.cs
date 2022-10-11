using System;
using System.Diagnostics.Metrics;

namespace ATM
{
    class ATM
    {

        public List<Account> Accounts { get; set; }

        // Constructor
        public ATM(List<Account> accounts)
        {
            this.Accounts = accounts;
        }

        bool isUserLoggedIn = false;
        Account currentUser;

        // Add account
        public void Register(string name, string password, int balance)
        {
            Accounts.Add(new Account(name, password, balance));
        }

        // Logging into account.
        public void Login(string name, string password)
        {
            if (isUserLoggedIn == false)
            {
                if (Accounts.Where(a => a.GetName() == name && a.GetPassword() == password).Count() > 0)
                {
                    currentUser = Accounts.Where(a => a.GetName() == name && a.GetPassword() == password).First();
                    isUserLoggedIn = true;
                }
            }
            Console.WriteLine($"Hello, {currentUser.GetName()}");
        }

        // Logout if a user is logged in
        public void Logout()
        {
            if (isUserLoggedIn == true)
            {
                isUserLoggedIn = false;
                currentUser = null;
                Console.WriteLine("You are now logged out");
            }
        }

        // Check balance if user is logged in
        public void CheckBalance()
        {
            if (isUserLoggedIn == true)
            {
                Console.WriteLine($"Your current balance is ${currentUser.GetBalance()}");
            }
        }

        // Deposit if user is logged in
        public void Deposit()
        {

            if (isUserLoggedIn == true)
            {
                int updatedBalance;
                Console.WriteLine("Enter the amount your would like to deposit");
                string depositAmount = Console.ReadLine();
                int deposit = int.Parse(depositAmount);

                updatedBalance = currentUser.GetBalance() + deposit;
                currentUser.SetBalance(updatedBalance);
            }

        }

        // Withdraw if user is logged in
        public void Withdraw()
        {
            int updateBalance;

            if (isUserLoggedIn == true)
            {

                Console.WriteLine("Enter the amount you would like to  withdrawal");
                string withdrawalAmount = Console.ReadLine();
                int withdraw = int.Parse(withdrawalAmount);
                int currentBalance = currentUser.GetBalance();

                if (withdraw > currentBalance)
                {
                    Console.WriteLine("Not enough funds to withdrawal");
                }
                else
                {
                    updateBalance = currentBalance - withdraw;

                    currentUser.SetBalance(updateBalance);
                }
            }
        }
    }
}
