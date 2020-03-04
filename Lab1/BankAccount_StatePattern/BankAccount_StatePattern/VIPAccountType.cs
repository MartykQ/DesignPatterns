using System;

// State pattern
namespace BankAccount_StatePattern
{
    // Reprezentuje rodzaj konta VIP - we wzorcu State pełni rolę "Concrete State"
    public class VIPAccountType : AccountType
    {
        // Operacja wypłaty dla konta VIP
        //
        // Obiekt Account wywoła tę wersję metody Withdraw(),
        // jeśli znajdzie się w "stanie" VIPAccountType
        public override void Withdraw(Account account, double amount)
        {
            if (account.Balance < amount)
            {
                Console.WriteLine("Withdrawal operation of {0} from VIP Account of {1} failed", amount, account.Owner);
                return;
            }
            
            account.Balance -= amount;
            Console.WriteLine("{0} was withdrowed from {1} VIP account", amount, account.Owner);
        }

        // operacja zmiany rodzaju konta
        //
        // Obiekt Account wywoła tę wersję metody ChangeAccountType(),
        // jeśli znajdzie się w "stanie" VIPAccountState.
        public override void ChangeAccountType(Account account)
        {
            // konto VIP można zmienić na Standard być bez żadnych warunków
            account.AccountType = new StandardAccountType();
            Console.WriteLine("VIP account: {0} is changed to Standard", account.Owner);
        }
    }
}
