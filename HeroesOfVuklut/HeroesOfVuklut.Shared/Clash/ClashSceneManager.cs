using System;

public class ClashSceneManager : SceneManager<ClashSceneManager> {
    private ClashState _currentClash;

    public ClashSceneManager(ISceneNavigator sceneNavigator) : base(sceneNavigator)
    {
    }

    public void PrepareClash(ClashState state){
        _currentClash = state; 
    }

    public override void BeginScene(SceneParameter<ClashSceneManager> sceneParameter)
    {
        base.BeginScene(sceneParameter);
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
}
