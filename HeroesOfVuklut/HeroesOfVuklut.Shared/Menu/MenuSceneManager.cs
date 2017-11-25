using HeroesOfVuklut.Engine.IO;
using HeroesOfVuklut.Engine.Scenes;
using System;

namespace HeroesOfVuklut.Shared.Menu
{
    public class MenuSceneManager : SceneManager<MenuSceneManager>
    {
        public MenuSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface, IGraphicElementFactory graphicElementFactory) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
        {
        }

        public override void BeginScene(SceneParameter<MenuSceneManager> sceneParameter)
        {
            base.BeginScene(sceneParameter);
        }

        public override Type GetSceneType()
        {
            return typeof(MenuSceneManager);
        }

        public override void ProcessInput()
        {

        }

        public override void Update(TimeSpan elapsedGameTime)
        {
            SceneNavigator.GotoScene(typeof(WorldSceneManager), WorldSceneManager.WorldSceneParameter.Default);
        }
    }
}
