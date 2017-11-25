using HeroesOfVuklut.Engine.Scenes;
using System;
using System.Collections.Generic;
using System.Text;
using HeroesOfVuklut.Engine.IO;

namespace HeroesOfVuklut.Shared.Units
{
    public class UnitDefinitionSceneManager : SceneManager<UnitDefinitionSceneManager>
    {
        public UnitDefinitionSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface, IGraphicElementFactory graphicElementFactory) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
        {
        }

        public override Type GetSceneType()
        {
            return typeof(UnitDefinitionSceneManager);
        }

        public override void ProcessInput()
        {

        }

        public class UnitDefinitionSceneParameter : SceneParameter<UnitDefinitionSceneManager>
        {
            public UnitDefinitionSceneParameter()
            {
            }

            public static UnitDefinitionSceneParameter Default { get { return null; } }
        }
    }
}
