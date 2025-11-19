namespace BankAccountLibrary
{
    public class SavingsAccount : Account
    {
        public SavingsAccount() { }
        public SavingsAccount(string name, int accountNumber, AccountType accountType, decimal balance):base(name, accountNumber, accountType, balance)
        {
        
        }
        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive");
            }
            else if (amount > Balance)
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
