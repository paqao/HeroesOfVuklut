using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.IO;
using HeroesOfVuklut.Engine.Localization;
using HeroesOfVuklut.Engine.Saves;
using HeroesOfVuklut.Engine.Scenes;
using HeroesOfVuklut.Shared.GameSaves;
using HeroesOfVuklut.Shared.GameSaves.Services;
using HeroesOfVuklut.Shared.NewGame;
using HeroesOfVuklut.Shared.Settings;
using HeroesOfVuklut.Shared.World;
using System;

namespace HeroesOfVuklut.Shared.Menu
{
    [DefaultScene]
    [SceneInject]
    public class MenuSceneManager : SceneManager<MenuSceneManager>
    {
        [InjectParameter]
        public IGameSavesManager<VuklutSaveGameInfo> GameSavesManager { get; set; }

        private IGraphicButton _loadGameButton;
        private IGraphicButton _newGameButton;
        private IGraphicButton _settingsButton;
        private CursorPosition _cursor;
        private bool _hasSave;

        public MenuSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface, IGraphicElementFactory graphicElementFactory) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
        {
            _newGameButton = graphicElementFactory.CreateButton(ButtonType.Rectangle);
            _loadGameButton = graphicElementFactory.CreateButton(ButtonType.Rectangle);
            _settingsButton = graphicElementFactory.CreateButton(ButtonType.Rectangle);

        }

        public override void BeginScene(SceneParameter<MenuSceneManager> sceneParameter)
        {
            base.BeginScene(sceneParameter);

            _hasSave = GameSavesManager.HasSave();

            _settingsButton.X = 30;
            _settingsButton.Y = 130;
            _settingsButton.ItemWidth = 200;
            _settingsButton.ItemHeight = 30;

            _loadGameButton.X = 30;
            _loadGameButton.Y = 100;
            _loadGameButton.ItemWidth = 200;
            _loadGameButton.ItemHeight = 30;

            _newGameButton.X = 30;
            _newGameButton.Y = 70;
            _newGameButton.ItemWidth = 200;
            _newGameButton.ItemHeight = 30;
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
                if (_hasSave && _loadGameButton.IsOver(cursor))
                {
                    SceneNavigator.GotoScene(typeof(LoadGameSceneManager), null);
                }
                if (_newGameButton.IsOver(cursor))
                {
                    SceneNavigator.GotoScene(typeof(NewGameSceneManager), null);
                }
                if (_settingsButton.IsOver(cursor))
                {
                    SceneNavigator.GotoScene(typeof(GameSettingsSceneManager), null);
                }
            }

            _cursor = cursor;
        }

        public override void Draw()
        {
            GraphicsInterface.DrawText(30, 30, LocalizedSource.GetLocalized("Welcome"));
            GraphicsInterface.DrawText(30, 70, LocalizedSource.GetLocalized("NewGame"));

            if (_hasSave)
            {
                GraphicsInterface.DrawText(30, 100, LocalizedSource.GetLocalized("LoadGame"));
            }

            GraphicsInterface.DrawText(30, 130, LocalizedSource.GetLocalized("Settings"));


            GraphicsInterface.Draw(_cursor.PositionX, _cursor.PositionY, 16, 16, "cursor");

            base.Draw();
        }

        public override void Update(TimeSpan elapsedGameTime)
        {
           // SceneNavigator.GotoScene(typeof(WorldSceneManager), WorldSceneManager.WorldSceneParameter.Default);
        }
    }
}
