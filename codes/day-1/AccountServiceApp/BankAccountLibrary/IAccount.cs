namespace BankAccountLibrary
{
    public interface IAccount
    {
        int AccountNumber { get; set; }
        AccountType AccountType { get; set; }
        decimal Balance { get; }
        string Name { get; set; }

        void Deposit(decimal amount);
        void Withdraw(decimal amount);
    }
}