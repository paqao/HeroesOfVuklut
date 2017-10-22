public abstract class SceneManager {
  virtual void Update(decimal step){
  }
  
  virtual void BeginScene<T>(T sceneParameter) where T : SceneManager<typeof(this)> {
    
  }
}
