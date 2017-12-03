using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HeroesOfVuklut.Engine.Game;
using HeroesOfVuklut.Engine.Scenes;
using HeroesOfVuklut.Engine.Context;

namespace HeroesOfVuklut.Engine.DI
{
    class ContainerSystem : IContainerSystem
    {

        public ContainerSystem()
        {
            var container = new ContainerSystemItem<ContainerSystem, IContainerSystem>()
            {
                Instance = this,
                HasInstance = true
            };
            Items.Add(container);
        }

        protected class ContainerSystemItem<T, U> : ContainerSystemItem where T : class, U
        {
            public override Type Implementation { get; } = typeof(T);
            public override Type Interface { get; } = typeof(U);

            public T InstanceImpl { get; protected set; }
            public U InstanceInterface { get; protected set; }

            public override void Create(ContainerSystem context)
            {
                var allConstructors = Implementation.GetConstructors();
                var constructorParam = allConstructors.First();
                var methodParameters = constructorParam.GetParameters();
                
                var callParameters = new List<object>{ };

                foreach (var param in methodParameters)
                {
                    var paramType = param.ParameterType;

                    var resolveMethod = typeof(ContainerSystem).GetMethod("Resolve");
                    var method = resolveMethod.MakeGenericMethod(new Type[] { paramType });
                    var methodResult = method.Invoke(context, new object[] { });
                    
                    callParameters.Add(methodResult);
                }

                var created = constructorParam.Invoke(callParameters.ToArray()) as T;

                InstanceImpl = created;
                InstanceInterface = created;
                Instance = created;

                base.Create(context);
            }
        } 

        protected abstract class ContainerSystemItem
        {
            public bool HasInstance { get; set; } = false;
            public virtual Type Implementation { get; }
            public virtual Type Interface { get; }
            public virtual void Create(ContainerSystem context)
            {
                HasInstance = true;
            }

            public virtual object Instance { get; set; }
        }

        private IList<ContainerSystemItem> Items { get; } = new List<ContainerSystemItem>();
        private IList<ContainerSystemItem> Scenes { get; } = new List<ContainerSystemItem>();

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
                itemDefination.Create(this);
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
            foreach (var item in types.Where(t => t.GetCustomAttribute< SceneInjectAttribute>() != null)) 
            {
                var addScene = GetType().GetMethod("AddScene");
                var genericMethod = addScene.MakeGenericMethod(new Type[] { item });
                genericMethod.Invoke(this, new object[] { });
            }
        }

        public T AddScene<T>() where T : SceneManager<T>
        {
            var containerSystemItem = new ContainerSystemItem<T, T>();
            Scenes.Add(containerSystemItem);

            containerSystemItem.Create(this);

            var sceneNavigator = Resolve<ISceneNavigator>();
            sceneNavigator.Scenes.AddScene(containerSystemItem.InstanceImpl);

            return containerSystemItem.InstanceImpl;
        }

        public void AddGameData<T, U>(T gameData, U gameSettings)
            where T : IGameEntity
            where U : IGameSettings
        {
            var targetType = typeof(IGameDataBased<T>);
            var methodToResolve = GetType().GetMethod("Resolve");
            foreach (var item in Items)
            {
                var interfaces = item.Implementation.GetInterfaces();
                
                var gameDataBased = interfaces.FirstOrDefault(inf => inf.Name == targetType.Name);

                if(gameDataBased != null)
                {
                    var genericMethod = methodToResolve.MakeGenericMethod(item.Interface);

                    var newItem = genericMethod.Invoke(this, new object[] { });
                    var gameDataBasedItem = newItem as IGameDataBased<T>;
                    gameDataBasedItem.SetGameData(gameData);
                }
            }
        }
    }
}
