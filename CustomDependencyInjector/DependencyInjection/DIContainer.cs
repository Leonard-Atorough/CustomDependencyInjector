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

    internal T GetService<T>()
    {
        var descriptor = _serviceDescriptors.
            SingleOrDefault(x => x.Key == typeof(T)).Value;

        if (descriptor == null)
        {
            throw new NullReferenceException($"Service of type {typeof(T).Name} isn't registered");
        }

        if (descriptor.Implementation != null)
        {
            return (T)descriptor.Implementation;
        }

        return default;
    }
}