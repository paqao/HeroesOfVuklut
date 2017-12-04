using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.IO;
using HeroesOfVuklut.Engine.Localization;
using HeroesOfVuklut.Engine.Scenes;
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

        public override void Draw()
        {
            GraphicsInterface.DrawText(30, 30, LocalizedSource.GetLocalized("Welcome"));
            base.Draw();
        }

        public override void Update(TimeSpan elapsedGameTime)
        {
           // SceneNavigator.GotoScene(typeof(WorldSceneManager), WorldSceneManager.WorldSceneParameter.Default);
        }
    }
}
