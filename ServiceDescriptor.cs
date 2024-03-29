namespace Custom_DI_Container
{
    internal class ServiceDescriptor
    {
        public Type ServiceType { get; } = null!;
        public Type ImplementationType { get; } = null!;
        public object? SingletonImplementation { get; internal set; }
        public Lifetime Lifetime { get; }

        public ServiceDescriptor(Type serviceType, Type implementationType, Lifetime lifetime)
        {
            ServiceType = serviceType;
            ImplementationType = implementationType;
            Lifetime = lifetime;
        }
    }
}
