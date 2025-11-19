namespace DIWithReflection
{
    public enum ServiceLifetime
    {
        Singleton,
        Transient,
        Scoped
    }
    public class ServiceDescriptor
    {
        public Type ServiceType { get; set; }
        public Type ImplementationType { get; set; }
        public ServiceLifetime Lifetime { get; set; }
    }
    public class Provider : IProvider
    {
        private List<ServiceDescriptor> _registeredTypes;
        public Provider(List<ServiceDescriptor> registeredTypes)
        {
            _registeredTypes = registeredTypes;
        }
        public TService GetService<TService>()
        {
            if (_registeredTypes.Any(sd => sd.ServiceType == typeof(TService)))
            {
                ServiceDescriptor? desc = _registeredTypes.Find(rt => rt.ServiceType == typeof(TService));
                if (desc != null)
                {
                    Type impl = desc.ImplementationType;
                    return (TService)Activator.CreateInstance(impl);
                }
                else
                {
                    throw new Exception("No implementation found");
                }
            }
            else
            {
                throw new Exception("Service not registered");
            }
        }
    }
    public class ServiceRegistry : IServiceRegistry
    {
        private static List<ServiceDescriptor> _registeredTypes = new List<ServiceDescriptor>();

        private static Provider _provider = new Provider(_registeredTypes);

        public ServiceRegistry Add<TInterface, TImplementation>(ServiceLifetime serviceLifetime)
        {
            Type svc = typeof(TInterface);
            Type impl = typeof(TImplementation);
            _registeredTypes.Add(new ServiceDescriptor
            {
                ServiceType = svc,
                ImplementationType = impl,
                Lifetime = serviceLifetime
            });
            return this;
        }
        public Provider Build()
        {
            if (_provider == null)
                _provider = new Provider(_registeredTypes);

            return _provider;
        }
    }
}
