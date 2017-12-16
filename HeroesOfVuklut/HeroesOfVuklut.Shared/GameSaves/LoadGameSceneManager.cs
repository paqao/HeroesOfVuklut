using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.IO;
using HeroesOfVuklut.Engine.Saves;
using HeroesOfVuklut.Engine.Scenes;
using HeroesOfVuklut.Shared.GameSaves.Services;
using HeroesOfVuklut.Shared.Menu;
using System;
using System.Linq;

namespace HeroesOfVuklut.Shared.GameSaves
{

    [SceneInject]
    public class LoadGameSceneManager : SceneManager<LoadGameSceneManager>
    {
        [InjectParameter]
        public IGameSavesManager<VuklutSaveGameInfo> GameSavesManager { get; set; }

        private IListElement<VuklutSaveGameInfo> _saves = null;

        private CursorPosition _cursor;

        public LoadGameSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface, IGraphicElementFactory graphicElementFactory) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
        {
            _saves = graphicElementFactory.CreateListElement<VuklutSaveGameInfo>();
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

            _saves.InnerList = GameSavesManager.GetAllSaves();
        }

        public override void Draw()
        {

            GraphicsInterface.Draw(_cursor.PositionX, _cursor.PositionY, 16, 16, "cursor");

            var saves = _saves.InnerList;

            for (int i = 0; i < saves.Count; i++)
            {
                GraphicsInterface.DrawText(30, 70 + i * 30, saves.ElementAt(i).SaveName);
            }

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
