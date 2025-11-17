using BankAccountLibrary;
using Microsoft.Extensions.DependencyInjection;

namespace AccountServiceFrontEnd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection registry = new ServiceCollection();
            IKeyedServiceProvider provider = registry.Add(new ServiceDescriptor(typeof(IAccountService),factory=>factory.)
                 .BuildServiceProvider();

            //SavingsAccount savingsAccount = new SavingsAccount("John Doe", 123456, AccountType.Savings, 1000m);
            //CurrentAccount currentAccount = new CurrentAccount("John Doe", 123456, AccountType.Savings, 1000m, 1000m);

            //savingsAccount.Deposit(500m);
            //Console.WriteLine(savingsAccount.Balance);
            //currentAccount.Withdraw(1200m);
            //Console.WriteLine(currentAccount.Balance);
        }
    }
}
