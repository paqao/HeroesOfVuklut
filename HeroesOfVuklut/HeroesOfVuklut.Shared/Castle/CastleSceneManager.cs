using System;

public class CastleSceneManager : SceneManager<CastleSceneManager>
{
    public CastleSceneManager(ISceneNavigator sceneNavigator) : base(sceneNavigator)
    {
    }

    public override Type GetSceneType()
    {
        return typeof(CastleSceneManager);
    }
}
