using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDependencyInjector.DependencyInjection
{
    internal class ServiceDescriptor
    {
        public Type ServiceType { get; }
        public object Implementation { get; }

        public ServiceLifetime Lifetime { get; }

        public ServiceDescriptor(object implementation, ServiceLifetime lifetime)
        {
            ServiceType = implementation.GetType();
            Implementation = implementation;
            Lifetime = lifetime;
        }

        public ServiceDescriptor(Type serviceType, ServiceLifetime lifetime)
        {
            ServiceType = serviceType;
            Implementation = Activator.CreateInstance(serviceType);
            Lifetime = lifetime;
        }

    }
}
