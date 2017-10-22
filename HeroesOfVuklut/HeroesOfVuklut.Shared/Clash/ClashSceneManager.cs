using System;

public class ClashSceneManager : SceneManager<ClashSceneManager> {
    private ClashState _currentClash;
  
    public void PrepareClash(ClashState state){
        _currentClash = state; 
    }

    public override void BeginScene(SceneParameter<ClashSceneManager> sceneParameter)
    {
        base.BeginScene(sceneParameter);
    }

    public override void Update(decimal step)
    {
    }

    public override void Draw()
    {
    }
}
