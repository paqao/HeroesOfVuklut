using HeroesOfVuklut.Engine.IO;
using HeroesOfVuklut.Engine.Scenes;
using System;

public class CastleSceneManager : SceneManager<CastleSceneManager>
{
    public CastleSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface, IGraphicElementFactory graphicElementFactory) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
    {
    }

    public override Type GetSceneType()
    {
        return typeof(CastleSceneManager);
    }

    public override void ProcessInput()
    {
    }
}
