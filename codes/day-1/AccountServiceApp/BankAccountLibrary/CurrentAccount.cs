namespace BankAccountLibrary
{
    public class CurrentAccount : Account
    {
        private decimal overdraftLimit;

        public CurrentAccount() { }
        public CurrentAccount(string name, int accountNumber, AccountType accountType, decimal balance, decimal overdraftLimit) : base(name, accountNumber, accountType, balance)
        {
            this.overdraftLimit = overdraftLimit;
        }

        public decimal OverdraftLimit
        {
            get => overdraftLimit;
            set => overdraftLimit = value;
        }
        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive");
            }
            else if (amount > Balance + overdraftLimit)
            {
                throw new InvalidOperationException("Insufficient funds");
            }
            else
            {
                Balance -= amount;
            }
        }
    }
}
