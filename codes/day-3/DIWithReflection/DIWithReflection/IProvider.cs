namespace DIWithReflection
{
    public interface IProvider
    {
        TService GetService<TService>();
    }
}