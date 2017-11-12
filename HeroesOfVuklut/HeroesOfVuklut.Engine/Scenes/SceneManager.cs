using HeroesOfVuklut.Engine.IO;
using System;

namespace HeroesOfVuklut.Engine.Scenes
{

    public abstract class SceneManager<T> : SceneManager
    {
        protected IInputInterface InputInterface { get; }
        protected ISceneNavigator SceneNavigator { get; }
        protected IGraphicsInterface GraphicsInterface { get; }

        public SceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface)
        {
            SceneNavigator = sceneNavigator;
            InputInterface = inputInterface;
            GraphicsInterface = graphicsInterface;
        }

        public SceneManager(ISceneNavigator sceneNavigator)
        {
            SceneNavigator = sceneNavigator;
        }

        public virtual SceneParameter<T> GetDefault()
        {
            return null;
        }

        public virtual void BeginScene(SceneParameter<T> sceneParameter)
        {

        }

        public override void BeginScene(SceneParameter sceneParameter)
        {
            var myParameter = sceneParameter as SceneParameter<T>;

            BeginScene(myParameter);
        }

        public abstract class SceneParameter<U> : SceneParameter where U : T
        {

        }
    }

    public abstract class SceneManager
    {

        public abstract Type GetSceneType();
        public virtual SceneParameter DefaultParameter { get; } = null;

        public virtual void BeginScene(SceneParameter sceneParameter)
        {

        }

        public virtual void Draw()
        {

        }

        public abstract class SceneParameter
        {

        }

        public virtual void Update(TimeSpan elapsedGameTime)
        {
        }

        public virtual void ClearScene()
        {

        }

        public abstract void ProcessInput();
    }
}
