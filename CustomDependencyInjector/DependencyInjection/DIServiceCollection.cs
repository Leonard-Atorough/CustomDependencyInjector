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
    internal void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
    {
        _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton));
    }
    internal void RegisterTransient<TService>()
    {
        _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifetime.Transient));
    }
    internal void RegisterTransient<TService, TImplementation>() where TImplementation : TService
    {
        _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));
    }

    internal DIContainer GenerateContainer()
    {
        return new DIContainer(_serviceDescriptors);
    }
}