namespace Custom_DI_Container
{
    internal class Container
    {
        private readonly List<ServiceDescriptor> _serviceDescriptors = [];

        public void AddTransient<TContract, TImplementation>() where TImplementation : TContract
        {
            var serviceDescriptor = new ServiceDescriptor(typeof(TContract), typeof(TImplementation), Lifetime.Transient);
            _serviceDescriptors.Add(serviceDescriptor);
        }

        public void AddSingleton<TContract, TImplementation>() where TImplementation : TContract
        {
            var serviceDescriptor = new ServiceDescriptor(typeof(TContract), typeof(TImplementation), Lifetime.Singleton);
            _serviceDescriptors.Add(serviceDescriptor);
        }
        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        private object GetService(Type type)
        {
            var serviceDescriptor = _serviceDescriptors.FirstOrDefault(x => x.ContractType == type)
                ?? throw new Exception($"Service {type.Name} not found on the DI Container");

            if (serviceDescriptor.SingletonImplementation != null) //Singleton instance
                return serviceDescriptor.SingletonImplementation;

            var implementationType = serviceDescriptor.ImplementationType;

            if (implementationType.IsInterface || implementationType.IsAbstract)
                throw new Exception("Interfaces and abstract classes cannot be instantiated");

            var implementation = ImplementationResolver(implementationType);

            if (serviceDescriptor.Lifetime == Lifetime.Singleton)
                serviceDescriptor.SingletonImplementation = implementation;

            return implementation;
        }

        private object ImplementationResolver(Type implementationType)
        {
            var constructor = implementationType.GetConstructors().FirstOrDefault() ?? throw new Exception();
            var parameters = constructor.GetParameters().Select(x => GetService(x.ParameterType)).ToArray() ?? throw new Exception();

            return Activator.CreateInstance(implementationType, parameters) ?? throw new Exception("Not found a constructor that best fits the parameters");
        }
    }
}
