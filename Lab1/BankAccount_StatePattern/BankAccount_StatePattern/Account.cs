using System;

// State pattern
namespace BankAccount_StatePattern
{
    // Reprezentuje konto bankowe - we wzorcu "State" pełni rolę "Context"
    //
    // Obiekt typu Account zawiera referencje do jednego obiektu typu AccountType.
    // Obiekt typu Account może zmienić "stan" poprzez zmianę skojarzonego z nim obiektu AccountType.
    public class Account
    {
        // właściciel konta
        private string _owner;
        public string Owner
        {
            get { return this._owner; }
            set { this._owner = value; }
        }

        // saldo
        private double _balance;
        public double Balance
        {
            get { return this._balance; }
            set { this._balance = value;}   // docelowo należy "opakować" lub użyć "Proxy"
        }
    
        // "Stan" - reprezentuje rodzaj konta (Junior, Standard, VIP).
        private AccountType _accountType;
        public AccountType AccountType
        {
            get { return this._accountType; }
            set { this._accountType = value; }
        }

        public Account(string owner)
        {
            this._owner = owner;
            this._accountType = new JuniorAccountType();
        }

        // operacja wypłaty
        public void Withdraw(double amount)
        {
            // Deleguje wykonanie operacji do obiektu typu AccountType,
            // wywołując na nim polimorficzną metodę Withdraw().
            this._accountType.Withdraw(this, amount);
        }

        // operacja zmiany "stanu" (rodzaju konta)
        public void ChangeAccountType()
        {
            // Deleguje wykonanie operacji do obiektu typu AccountType,
            // wywołując na nim polimorficzną metodę ChangeState().
            this._accountType.ChangeAccountType(this);
        }

        // Operacja wpłaty na konto
        //
        // Ze względu na identyczne zachowanie metody Deposit() we wszystkich 
        // "stanach" - jej implementację umieszczono w klasie Account.
        public void Deposit(double amount)
        {
            this._balance += amount;

            Console.WriteLine("Deposit of {0} to {1} account", amount, this._owner);
            Console.WriteLine("The balanse of {0} account is equal {1}", this._owner, this._balance);
        }
    }
}
