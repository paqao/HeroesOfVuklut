using HeroesOfVuklut.Shared;
using System;

public class CastleSceneManager : SceneManager<CastleSceneManager>
{
    public CastleSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface) : base(sceneNavigator, inputInterface, graphicsInterface)
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
