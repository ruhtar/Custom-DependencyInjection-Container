namespace Custom_DI_Container
{
    internal class CustomContainer
    {
        private readonly List<ServiceDescriptor> _registers = [];

        public void RegisterTransient<TImpl, TService>() where TService : TImpl 
        {
            var serviceDescriptor = new ServiceDescriptor(typeof(TImpl), typeof(TService), ServiceLifetime.Transient);
            _registers.Add(serviceDescriptor);   
        }

        public void RegisterSingleton<TImpl, TService>() where TService : TImpl
        {
            var serviceDescriptor = new ServiceDescriptor(typeof(TImpl), typeof(TService), ServiceLifetime.Singleton);
            _registers.Add(serviceDescriptor);
        }

        public object GetService(Type type) 
        {
            var serviceDescriptor = _registers.FirstOrDefault(x => x.ServiceType == type);
            return null; //WIP
        }
    }
}
