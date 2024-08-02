namespace Custom_DI_Container
{
    internal class ServiceDescriptor
    {
        public Type ContractType { get; } = null!;
        public Type ImplementationType { get; } = null!;
        public object? SingletonImplementation { get; internal set; }
        public Lifetime Lifetime { get; }

        public ServiceDescriptor(Type contractType, Type implementationType, Lifetime lifetime)
        {
            ContractType = contractType;
            ImplementationType = implementationType;
            Lifetime = lifetime;
        }
    }
}
