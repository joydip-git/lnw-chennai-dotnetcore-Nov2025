using Microsoft.Extensions.DependencyInjection;

namespace BankAccountLibrary
{
    public class AccountService : IAccountService
    {
        private readonly IAccount account;
        private readonly IKeyedServiceProvider keyedServiceProvider;

        public AccountService(IKeyedServiceProvider keyedServiceProvider, int choice = 1)
        {
            this.keyedServiceProvider = keyedServiceProvider;
            this.account = choice switch
            {
                1 => keyedServiceProvider.GetRequiredKeyedService<IAccount>(AccountType.Savings),
                2 => keyedServiceProvider.GetRequiredKeyedService<IAccount>(AccountType.Current),
                _ => throw new ArgumentException("Invalid account type choice")
            };
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
