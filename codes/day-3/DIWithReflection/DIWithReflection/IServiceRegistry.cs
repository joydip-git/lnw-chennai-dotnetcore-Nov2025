namespace DIWithReflection
{
    public interface IServiceRegistry
    {
        ServiceRegistry Add<TInterface, TImplementation>();
        Provider Build();
    }
}