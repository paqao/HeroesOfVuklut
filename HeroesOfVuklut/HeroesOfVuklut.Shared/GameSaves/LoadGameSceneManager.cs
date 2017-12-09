using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.IO;
using HeroesOfVuklut.Engine.Scenes;
using System;

namespace HeroesOfVuklut.Shared.GameSaves
{

    [SceneInject]
    public class LoadGameSceneManager : SceneManager<LoadGameSceneManager>
    {
        public LoadGameSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface, IGraphicElementFactory graphicElementFactory) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
        {

        }

        public override Type GetSceneType()
        {
            return typeof(LoadGameSceneManager);
        }

        public override void ProcessInput()
        {

        }
    }
}
