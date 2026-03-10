using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp
{
    public class SavingsAccount:BankAccount
    {
        public decimal InterestRate { get; set; }

        public SavingsAccount(string owner, decimal interestRate) : base(owner + 
        "(" + interestRate + "%)")
        {
            InterestRate = interestRate;
        }

        public override string Deposit(decimal amount)
        {
            if (amount <= 0)
                return "Deposit amount must be greater than zero.";
            if(amount > 100000)
                return "Deposit amount exceeds the limit of $10,000.";
            
            decimal interest = amount * (InterestRate / 100);
            Balance += amount + interest;
            return $"Deposited {amount:C}. Interest earned: {interest:C}. New balance: {Balance:C}.";
        }
    }
}