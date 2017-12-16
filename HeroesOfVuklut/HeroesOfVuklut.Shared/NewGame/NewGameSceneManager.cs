using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.Scenes;
using System;
using System.Collections.Generic;
using System.Text;
using HeroesOfVuklut.Engine.IO;
using HeroesOfVuklut.Shared.Menu;
using HeroesOfVuklut.Shared.World;
using HeroesOfVuklut.Engine.Localization;

namespace HeroesOfVuklut.Shared.NewGame
{

    [SceneInject]
    public class NewGameSceneManager : SceneManager<NewGameSceneManager>
    {
        private IGraphicButton _startGameButton;
        private CursorPosition _cursor;

        public NewGameSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface, IGraphicElementFactory graphicElementFactory) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
        {
            _startGameButton = graphicElementFactory.CreateButton(ButtonType.Rectangle);
        }

        public override void BeginScene(SceneParameter<NewGameSceneManager> sceneParameter)
        {
            base.BeginScene(sceneParameter);

            _startGameButton.X = 30;
            _startGameButton.Y = 70;
            _startGameButton.ItemWidth = 200;
            _startGameButton.ItemHeight = 30;
        }

        public override Type GetSceneType()
        {
            return typeof(NewGameSceneManager);
        }

        public override void ProcessInput()
        {

            var cursor = InputInterface.GetCursor();

            var rightButton = InputInterface.IsClick("cursorRight");
            var leftButton = InputInterface.IsClick("cursorLeft");

            if (rightButton)
            {
                SceneNavigator.GotoScene(typeof(MenuSceneManager), null);
            }
            if (leftButton)
            {
                if (_startGameButton.IsOver(cursor))
                {
                    SceneNavigator.GotoScene(typeof(WorldSceneManager), null);
                }
            }

            _cursor = cursor;
        }

        public override void Draw()
        {
            _cursor = InputInterface.GetCursor();

            GraphicsInterface.DrawText(30, 70, LocalizedSource.GetLocalized("Start game"));
            GraphicsInterface.Draw(_cursor.PositionX, _cursor.PositionY, 16, 16, "cursor");

            base.Draw();

        }
    }
}
