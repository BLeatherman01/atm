using System;
namespace ATM
{
    class Account
    {
        // Properties
        private string Name;
        private string Password;
        private int Balance;

        // Constructor
        public Account(string name, string password, int balance)
        {
            this.Name = name;
            this.Password = password;
            this.Balance = balance;
        }

        // Methods
        public string GetName()
        {
            return Name;
        }

        public string GetPassword()
        {
            return Password;
        }

        public int GetBalance()
        {
            return Balance;
        }

        public void SetBalance(int balance)
        {
            this.Balance = balance;
        }

    }
}

