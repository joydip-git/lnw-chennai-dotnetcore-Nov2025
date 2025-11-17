namespace BankAccountLibrary
{
    public class AccountService : IAccountService
    {
        private readonly IAccount account;
        public AccountService(IAccount account)
        {
            this.account = account;
        }
        public decimal Withdraw(decimal amount)
        {
            account.Withdraw(amount);
            return account.Balance;
        }
        public decimal Deposit(decimal amount)
        {
            account.Deposit(amount);
            return account.Balance;
        }
    }
}
