using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.IO;
using HeroesOfVuklut.Engine.Scenes;
using HeroesOfVuklut.Shared.Menu;
using System;

namespace HeroesOfVuklut.Shared.GameSaves
{

    [SceneInject]
    public class LoadGameSceneManager : SceneManager<LoadGameSceneManager>
    {
        private CursorPosition _cursor;

        public LoadGameSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface, IGraphicElementFactory graphicElementFactory) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
        {

        }

        public override Type GetSceneType()
        {
            return typeof(LoadGameSceneManager);
        }

        public override void BeginScene(SceneParameter sceneParameter)
        {
            base.BeginScene(sceneParameter);

            StartScene(sceneParameter as SceneParameter<LoadGameSceneManager>);
        }

        public override void BeginScene(SceneParameter<LoadGameSceneManager> sceneParameter)
        {
            base.BeginScene(sceneParameter);

            StartScene(sceneParameter);
        }

        private void StartScene(SceneParameter<LoadGameSceneManager> sceneParameter)
        {
            _cursor = InputInterface.GetCursor();
        }

        public override void Draw()
        {
            GraphicsInterface.Draw(_cursor.PositionX, _cursor.PositionY, 16, 16, "cursor");

            base.Draw();
        }

        public override void ProcessInput()
        {
            var cursor = InputInterface.GetCursor();


            var rightButton = InputInterface.IsClick("cursorRight");

            if (rightButton)
            {
                SceneNavigator.GotoScene(typeof(MenuSceneManager), null);
            }

            _cursor = cursor;
        }
    }
}
