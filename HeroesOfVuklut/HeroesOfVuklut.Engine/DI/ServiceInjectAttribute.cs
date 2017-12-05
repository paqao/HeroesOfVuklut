using System;

namespace HeroesOfVuklut.Engine.DI
{
    public class ServiceInjectAttribute : Attribute
    {
        public Type Implementation { get; }
        public Type Service { get; }
        
        public ServiceInjectAttribute(Type serviceInterface, Type serviceImplementation)
        {
            Service = serviceInterface;
            Implementation = serviceImplementation;
        }

        public ServiceInjectAttribute(Type serviceType)
        {
            Service = serviceType;
            Implementation = serviceType;
        }
    }
}
