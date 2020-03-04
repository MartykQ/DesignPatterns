using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount_StatePattern
{
    class JuniorAccountType : AccountType
    {

        public static int withdrawLimit = 5000;
        public override void ChangeAccountType(Account account)
        {
            // Z Junior mozna przejsc na standard
            account.AccountType = new StandardAccountType();
        }

        public override void Withdraw(Account account, double amount)
        {
            if (amount <= JuniorAccountType.withdrawLimit)
            {
                account.Balance -= amount;
            }
            else
            {
                Console.WriteLine($"The amount is higher than this account type limmit: {JuniorAccountType.withdrawLimit}");
            }
        }
    }
}
