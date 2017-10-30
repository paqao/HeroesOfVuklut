using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Menu
{
    public class MenuSceneManager : SceneManager<MenuSceneManager>
    {
        public MenuSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface) : base(sceneNavigator, inputInterface, graphicsInterface)
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
