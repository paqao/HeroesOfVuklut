using HeroesOfVuklut.Shared;
using System;

public class WorldSceneManager : SceneManager<WorldSceneManager>
{
    public WorldSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface) : base(sceneNavigator, inputInterface)
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

    public override void Update(TimeSpan elapsedGameTime)
    {
        SceneNavigator.GotoScene(typeof(ClashSceneManager), ClashSceneManager.ClashSceneParameter.Default);
    }

    public override void ProcessInput()
    {

    }
}
