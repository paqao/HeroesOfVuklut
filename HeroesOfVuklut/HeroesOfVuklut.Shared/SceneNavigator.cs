public class SceneNavigator : ISceneNavigator {
  public SceneManager CurrentScene { get; set; }
  
  public void GotoScene<T>(T scene, SceneParameter<T> sceneParameter) where T : SceneManager {
    this.SceneManager = scene;
    
    this.SceneManager.BeginScene(sceneParameter);
  }
}
