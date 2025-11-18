using BankAccountLibrary;
using Microsoft.Extensions.DependencyInjection;

namespace AccountServiceFrontEnd
{
    internal class Program
    {
        static IKeyedServiceProvider ConfigureServices(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            //services.AddScoped<IAccount, SavingsAccount>();
            //services.AddScoped<IAccount, CurrentAccount>();

            //services.AddKeyedScoped<IAccount, SavingsAccount>("Savings");
            //services.AddKeyedScoped<IAccount, CurrentAccount>("Current");

            //services.AddKeyedScoped<IAccount, SavingsAccount>(AccountType.Savings);
            //services.AddKeyedScoped<IAccount, CurrentAccount>(AccountType.Current);

            services
                .AddKeyedScoped<IAccount, SavingsAccount>(
                AccountType.Savings,
                (p, x) => new SavingsAccount("joydip", 1001, AccountType.Savings, 10000)
                )
                .AddKeyedScoped<IAccount, CurrentAccount>(
                AccountType.Current,
                (p, x) => new CurrentAccount("joydip", 1001, AccountType.Current, 10000, 2000)
                );

            services.AddScoped<IAccountService, AccountService>();

            IKeyedServiceProvider provider = services.BuildServiceProvider();
            return provider;
        }
        static void Main(string[] args)
        {
            IKeyedServiceProvider provider = ConfigureServices(args);
            IAccountService accountService = provider.GetRequiredService<IAccountService>();

            Console.WriteLine(accountService.Deposit(2000));
            Console.WriteLine(accountService.Withdraw(14000));

            /*
           IAccount savingsAcc = provider.GetRequiredKeyedService<IAccount>(AccountType.Savings);

            savingsAcc.Deposit(2000);
            Console.WriteLine(savingsAcc.Balance);

            savingsAcc.Withdraw(1000);
            Console.WriteLine(savingsAcc.Balance);
            */
        }
    }
}
