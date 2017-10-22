using HeroesOfVuklut.Shared;
using System;

public class ClashSceneManager : SceneManager<ClashSceneManager> {
    private ClashState _currentClash;

    public ClashSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface) : base(sceneNavigator, inputInterface)
    {
    }

    public void PrepareClash(ClashState state) {
        _currentClash = state;
    }

    public override void BeginScene(SceneParameter<ClashSceneManager> sceneParameter)
    {
        base.BeginScene(sceneParameter);
        var parsedParam = sceneParameter as ClashSceneParameter;

        
    }

    public override void Update(TimeSpan step)
    {

    }

    public override void Draw()
    {

    }

    public override Type GetSceneType()
    {
        return typeof(ClashSceneManager);
    }

    public override void ProcessInput()
    {
        
    }

    public class ClashSceneParameter : SceneParameter<ClashSceneManager>
    {
        public ClashSceneParameter()
        {

        }

        public static ClashSceneParameter Default { get { return null; } }
    }
}
