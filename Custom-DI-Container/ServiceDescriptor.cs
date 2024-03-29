namespace Custom_DI_Container
{
    internal class ServiceDescriptor
    {
        public Type ImplementationType { get; }
        public Type ServiceType { get; }
        public object Implementation { get; set; }
        public ServiceLifetime Lifetime { get; }

        public ServiceDescriptor(Type implementationType, Type serviceType, ServiceLifetime lifetime)
        {
            ServiceType = serviceType;
            ImplementationType = implementationType;
            Lifetime = lifetime;
        }
    }
}
