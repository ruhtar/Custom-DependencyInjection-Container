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

        private object GetService(object type) 
        {
            var serviceDescriptor = _serviceDescriptors.FirstOrDefault(x => x.ServiceType == type);

            if (serviceDescriptor.Implementation != null)
            {
                return serviceDescriptor.Implementation;
            }

            var implementationType = serviceDescriptor.ImplementationType;

            var implementation = Activator.CreateInstance(implementationType);

            if (serviceDescriptor.Lifetime == ServiceLifetime.Singleton) 
            {
                serviceDescriptor.Implementation = implementation;
            }

            return implementation;
        }

        public T GetService<T>() {
            return (T)GetService(typeof(T));
        }
    }
}
