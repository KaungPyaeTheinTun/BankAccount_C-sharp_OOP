using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp
{
    public class BankAccount
    {
        public string? Owner { get; set; }
        public Guid AccountNumber { get; set; }
        public decimal Balance { get; protected set; }

        public BankAccount(string owner)
        {
            Owner = owner;
            AccountNumber = Guid.NewGuid();
            Balance = 0;
        }

        public virtual string Deposit(decimal amount)
        {
            if (amount <= 0)
                return "Deposit amount must be greater than zero.";
            if(amount > 100000)
                return "Deposit amount exceeds the limit of $10,000.";
            Balance += amount;
            return $"Deposited {amount:C}. New balance: {Balance:C}.";
        }

        public string Withdraw(decimal amount)
        {
            if (amount <= 0)
                return "Withdrawal amount must be greater than zero.";
            if (amount > Balance)
                return "Insufficient funds.";
            Balance -= amount;
            return $"Withdrew {amount:C}. New balance: {Balance:C}.";
        }
    }
}