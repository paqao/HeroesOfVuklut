using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.IO;
using HeroesOfVuklut.Engine.Localization;
using HeroesOfVuklut.Engine.Scenes;
using HeroesOfVuklut.Shared.GameSaves;
using HeroesOfVuklut.Shared.World;
using System;

namespace HeroesOfVuklut.Shared.Menu
{
    [DefaultScene]
    [SceneInject]
    public class MenuSceneManager : SceneManager<MenuSceneManager>
    {
        [InjectParameter]
        public ILocalizedSource LocalizedSource { get; set; }


        private IGraphicButton _loadGameButton;
        private CursorPosition _cursor;

        public MenuSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface, IGraphicElementFactory graphicElementFactory) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
        {
            _loadGameButton = graphicElementFactory.CreateButton(ButtonType.Rectangle);

        }

        public override void BeginScene(SceneParameter<MenuSceneManager> sceneParameter)
        {
            base.BeginScene(sceneParameter);

            _loadGameButton.X = 30;
            _loadGameButton.Y = 70;
            _loadGameButton.ItemWidth = 200;
            _loadGameButton.ItemHeight = 30;
            
        }

        public override Type GetSceneType()
        {
            return typeof(MenuSceneManager);
        }

        public override void ProcessInput()
        {
            var cursor = InputInterface.GetCursor();

            var leftButton = InputInterface.IsClick("cursorLeft");

            if (leftButton)
            {
                if (_loadGameButton.IsOver(cursor))
                {
                    SceneNavigator.GotoScene(typeof(LoadGameSceneManager), null);
                }
            }

            _cursor = cursor;
        }

        public override void Draw()
        {
            GraphicsInterface.DrawText(30, 30, LocalizedSource.GetLocalized("Welcome"));
            GraphicsInterface.DrawText(30, 70, LocalizedSource.GetLocalized("LoadGame"));


            GraphicsInterface.Draw(_cursor.PositionX, _cursor.PositionY, 16, 16, "cursor");

            base.Draw();
        }

        public override void Update(TimeSpan elapsedGameTime)
        {
           // SceneNavigator.GotoScene(typeof(WorldSceneManager), WorldSceneManager.WorldSceneParameter.Default);
        }
    }
}
