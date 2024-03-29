namespace Custom_DI_Container
{
    internal class Container
    {
        private readonly List<ServiceDescriptor> _serviceDescriptors = [];

        public void RegisterTransient<TImpl, TService>() where TService : TImpl
        {
            var serviceDescriptor = new ServiceDescriptor(typeof(TImpl), typeof(TService), ServiceLifetime.Transient);
            _serviceDescriptors.Add(serviceDescriptor);
        }

        public void RegisterSingleton<TImpl, TService>() where TService : TImpl
        {
            var serviceDescriptor = new ServiceDescriptor(typeof(TImpl), typeof(TService), ServiceLifetime.Singleton);
            _serviceDescriptors.Add(serviceDescriptor);
        }

        //TODO: Scoped?

        private object GetService(Type type)
        {
            var serviceDescriptor = _serviceDescriptors.FirstOrDefault(x => x.ServiceType == type)
                ?? throw new Exception($"Service {type.Name} not found on the DI Container");

            if (serviceDescriptor.SingletonImplementation != null) //Singleton instance
                return serviceDescriptor.SingletonImplementation;

            var implementationType = serviceDescriptor.ImplementationType;

            if (implementationType.IsInterface || implementationType.IsAbstract)
                throw new Exception("Interfaces and abstract classes cannot be instantiated");

            var implementation = ImplementationResolver(implementationType);

            if (serviceDescriptor.Lifetime == ServiceLifetime.Singleton)
            {
                serviceDescriptor.SingletonImplementation = implementation;
            }

            return implementation;
        }

        private object ImplementationResolver(Type implementationType)
        {
            var constructor = implementationType.GetConstructors().FirstOrDefault() ?? throw new Exception();
            var parameters = constructor.GetParameters().Select(x => GetService(x.ParameterType)).ToArray() ?? throw new Exception();

            return Activator.CreateInstance(implementationType, parameters);
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }
    }
}
