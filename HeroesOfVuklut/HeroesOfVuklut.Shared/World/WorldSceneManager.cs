using System;

public class WorldSceneManager : SceneManager<WorldSceneManager>
{
    public WorldSceneManager(ISceneNavigator sceneNavigator) : base(sceneNavigator)
    {
    }

    public override void BeginScene(SceneParameter<WorldSceneManager> sceneParameter)
    {
        var parameter = sceneParameter as WorldSceneParameter;
        base.BeginScene(sceneParameter);
    }

    public override Type GetSceneType()
    {
        return typeof(WorldSceneManager);
    }

    public class WorldSceneParameter :  SceneParameter<WorldSceneManager>
    {
        public static WorldSceneParameter Default { get { return null; } }
    }
}
