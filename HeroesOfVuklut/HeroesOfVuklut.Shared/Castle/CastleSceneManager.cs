using HeroesOfVuklut.Shared;
using System;

public class CastleSceneManager : SceneManager<CastleSceneManager>
{
    public CastleSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface) : base(sceneNavigator, inputInterface)
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
