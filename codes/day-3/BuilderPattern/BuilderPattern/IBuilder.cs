namespace BuilderPattern
{
    public interface IBuilder
    {
        IBuilder SetName(string name);
        IBuilder SetEmail(string email);
        IBuilder SetRole(string role);
        IBuilder SetAddress(string address);
        User Build();
    }
}
