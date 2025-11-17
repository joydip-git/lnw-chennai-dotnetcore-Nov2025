namespace BankAccountLibrary
{
    public interface IAccountService
    {
        decimal Deposit(decimal amount);
        decimal Withdraw(decimal amount);
    }
}