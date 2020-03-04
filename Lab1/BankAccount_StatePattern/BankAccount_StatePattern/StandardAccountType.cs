using System;

// State pattern
namespace BankAccount_StatePattern
{
    // Represents Standard Account type - it playes a role of "Concrete State" in State pattern
    public class StandardAccountType : AccountType
    {
        protected const double withdrawLimit = 5000;

        protected const double serviceFee = 3;

        // Operacja wypłaty dla konta Standard
        //
        // Obiekt Account wywoła tę wersję metody Withdraw(),
        // jeśli znajdzie się w "stanie" VIPAccountType.
        public override void Withdraw(Account account, double amount)
        {
            if ((amount > withdrawLimit) || (account.Balance < amount + serviceFee))
            {
                Console.WriteLine("Withdrawal operation of {0} from Standard Account of {1} failed", amount, account.Owner);
                return;
            }

            account.Balance -= amount + serviceFee;
            Console.WriteLine("{0} was withdrowed from {1} Standard account", amount, account.Owner);
        }

        // Operacja zmiany rodzaju konta
        //
        // Obiekt Account wywoła tę wersję metody ChangeAccountType(),
        // jeśli znajdzie się w "stanie" StandardAccountState.
        public override void ChangeAccountType(Account account)
        {
            // jeśli saldo jest większe od 30000, konto Standard może być zmienione na VIP
            if (account.Balance > 30000)
            {
                account.AccountType = new VIPAccountType();
                Console.WriteLine("{0} Standard account was changed to VIP", account.Owner);
            }
            else
                Console.WriteLine("The operation of changing {0} Standard account type to VIP failed", account.Owner);
        }
    }
}
