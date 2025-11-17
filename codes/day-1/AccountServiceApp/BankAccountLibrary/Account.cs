namespace BankAccountLibrary
{
    public abstract class Account : IAccount
    {
        private decimal balance;
        private string name;
        private int accountNumber;
        private AccountType accountType;

        public Account()
        {

        }

        public Account(string name, int accountNumber, AccountType accountType, decimal balance)
        {
            this.name = name;
            this.accountNumber = accountNumber;
            this.accountType = accountType;
            this.balance = balance;
        }

        public decimal Balance
        {
            get => balance;
            protected set => balance = value;
        }

        //expression-bodied property
        //public decimal Balance => balance;

        public string Name
        {
            get => name;
            set => name = value;
        }
        public int AccountNumber
        {
            get => accountNumber;
            set => accountNumber = value;
        }
        public AccountType AccountType
        {
            get => accountType;
            set => accountType = value;
        }

        public void Deposit(decimal amount)
        {
            balance += amount;
        }

        public abstract void Withdraw(decimal amount);
    }
}
