using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HeroesOfVuklut.Engine.DI
{
    class ContainerSystem : IContainerSystem
    {
        protected class ContainerSystemItem<T, U> : ContainerSystemItem where T : class, U
        {
            public override Type Implementation { get; } = typeof(T);
            public override Type Interface { get; } = typeof(U);

            public T InstanceImpl { get; protected set; }
            public U InstanceInterface { get; protected set; }

            public override void Create()
            {
                var item = Implementation.GetConstructor(new Type[] { } );

                var created = item.Invoke(new object[] { }) as T;

                InstanceImpl = created;
                InstanceInterface = created;
                Instance = created;

                base.Create();
            }
        } 

        protected abstract class ContainerSystemItem
        {
            public bool HasInstance { get; protected set; } = false;
            public virtual Type Implementation { get; }
            public virtual Type Interface { get; }
            public virtual void Create()
            {
                HasInstance = true;
            }

            public virtual object Instance { get; protected set; }
        }

        private IList<ContainerSystemItem> Items { get; } = new List<ContainerSystemItem>();

        public void AddDeclaration<T, U>() where T : class, U
        {
            var containerSystemItem = new ContainerSystemItem<T, U>();
            Items.Add(containerSystemItem);
        }
        
        public void AddDeclaration<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>() where T : class
        {
            var requestType = typeof(T);
            var itemDefination = Items.FirstOrDefault(x => x.Interface == requestType);

            if(itemDefination == null)
            {
                return default(T);
            }

            if (!itemDefination.HasInstance)
            {
                itemDefination.Create();
            }

            var instance = itemDefination.Instance as T;

            return instance;
        }

        public void AddAttributeDeclarations(Assembly assembly)
        {
            var types = assembly.GetTypes();

            var containerItemType = typeof(ContainerSystemItem<,>);
            foreach (var assemblyType in types.Where(t => t.GetCustomAttribute<ServiceInjectAttribute>() != null))
            {
                var assemblyAttribute = assemblyType.GetCustomAttribute<ServiceInjectAttribute>();
                
                Type[] typeArgs = { assemblyAttribute.Service, assemblyAttribute.Implementation };
                var makeme = containerItemType.MakeGenericType(typeArgs);
                var o = Activator.CreateInstance(makeme);
                Items.Add(o as ContainerSystemItem);
            }
        }
    }
}
