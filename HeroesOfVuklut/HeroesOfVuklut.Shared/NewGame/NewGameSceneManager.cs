using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.Scenes;
using System;
using System.Collections.Generic;
using System.Text;
using HeroesOfVuklut.Engine.IO;
using HeroesOfVuklut.Shared.Menu;

namespace HeroesOfVuklut.Shared.NewGame
{

    [SceneInject]
    public class NewGameSceneManager : SceneManager<NewGameSceneManager>
    {
        public NewGameSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface, IGraphicElementFactory graphicElementFactory) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
        {
        }

        public override Type GetSceneType()
        {
            return typeof(NewGameSceneManager);
        }

        public override void ProcessInput()
        {

            var rightButton = InputInterface.IsClick("cursorRight");

            if (rightButton)
            {
                SceneNavigator.GotoScene(typeof(MenuSceneManager), null);
            }
        }
    }
}
