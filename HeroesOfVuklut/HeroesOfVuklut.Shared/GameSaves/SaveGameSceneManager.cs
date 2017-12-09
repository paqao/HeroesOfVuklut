using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.IO;
using HeroesOfVuklut.Engine.Scenes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.GameSaves
{
    [SceneInject]
    public class SaveGameSceneManager : SceneManager<SaveGameSceneManager>
    {
        public SaveGameSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface, IGraphicElementFactory graphicElementFactory) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
        {

        }

        public override Type GetSceneType()
        {
            return typeof(SaveGameSceneManager);
        }

        public override void ProcessInput()
        {

        }
    }
}
