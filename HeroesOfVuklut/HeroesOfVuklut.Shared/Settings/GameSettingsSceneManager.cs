using HeroesOfVuklut.Engine.Scenes;
using System;
using System.Collections.Generic;
using System.Text;
using HeroesOfVuklut.Engine.IO;
using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.Game;
using HeroesOfVuklut.Shared.Menu;

namespace HeroesOfVuklut.Shared.Settings
{
    [SceneInject]
    public class GameSettingsSceneManager : SceneManager<GameSettingsSceneManager>
    {
        [InjectParameter]
        public ISettingsManager<GameSettings> SettingsManager { get; set; }

        public GameSettingsSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface, IGraphicElementFactory graphicElementFactory) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
        {
        }

        public override Type GetSceneType()
        {
            return typeof(GameSettingsSceneManager);
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
