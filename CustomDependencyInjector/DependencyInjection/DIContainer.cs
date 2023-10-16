using CustomDependencyInjector.DependencyInjection;

internal class DIContainer
{
    public Dictionary<Type, ServiceDescriptor> _serviceDescriptors = new();

    public DIContainer(List<ServiceDescriptor> serviceDescriptors)
    {
        foreach (var serviceDescriptor in serviceDescriptors)
        {
            _serviceDescriptors.Add(serviceDescriptor.ServiceType, serviceDescriptor);
        }
    }

    public object GetService(Type serviceType)
    {
        var descriptor = _serviceDescriptors.
    SingleOrDefault(x => x.Key == serviceType).Value;

        var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

        if (descriptor == null)
        {
            throw new NullReferenceException($"Service of type {serviceType.Name} isn't registered");
        }

        if (descriptor.Implementation != null)
        {
            return descriptor.Implementation;
        }

        if (actualType.IsAbstract || actualType.IsInterface)
        {
            throw new InvalidOperationException("Cannot instantiate abstract classes or interfaces");
        }

        var implementation = Activator.CreateInstance(actualType, GetDependencies(actualType));

        if (descriptor.Lifetime == ServiceLifetime.Singleton)
        {
            descriptor.Implementation = implementation;
        }

        return implementation;
    }

    private object[] GetDependencies(Type actualType)
    {
        var constructorInfo = actualType.GetConstructors().First();

        var parameters = constructorInfo.GetParameters().Select(x => GetService(x.ParameterType)).ToArray();
        return parameters;
    }

    internal T GetService<T>()
    {
        return (T)GetService(typeof(T));
    }
}