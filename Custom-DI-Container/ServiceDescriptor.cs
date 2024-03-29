namespace Custom_DI_Container
{
    internal class ServiceDescriptor
    {
        public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            ServiceType = serviceType;
            ImplementationType = implementationType;
            Lifetime = lifetime;
        }

        public Type ServiceType { get; }
        public Type ImplementationType { get; }
        public object Implementation { get; internal set; }
        public ServiceLifetime Lifetime { get; }
    }
}
