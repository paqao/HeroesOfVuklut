public abstract class SceneManager {
  virtual void Update(decimal step){
  }
  
  virtual void BeginScene(T sceneParameter) where T : SceneParameter<typeof(this)> {
    
  }
}
