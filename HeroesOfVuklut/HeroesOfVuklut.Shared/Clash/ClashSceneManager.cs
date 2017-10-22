public class ClashSceneManager : SceneManager {
  private ClashState _currentClash;
  
  public void PrepareClash(ClashState state){
    _currentClash = state; 
  }
  
  public override BeginScene(ClashSceneParameter clashSceneParameter){
     
  }
}
