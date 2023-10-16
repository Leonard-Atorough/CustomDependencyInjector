namespace CustomDependencyInjector.DependencyInjection;

internal class DIServiceCollection
{
    private List<ServiceDescriptor> _serviceDescriptors = new();
   
    internal void RegisterSingleton<TService>(TService Implementation)
    {
        _serviceDescriptors.Add(new ServiceDescriptor(Implementation, ServiceLifetime.Singleton));
    }

    internal void RegisterSingleton<TService>()
    {
        _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifetime.Singleton));
    }

    internal DIContainer GenerateContainer()
    {
        return new DIContainer(_serviceDescriptors);
    }
}