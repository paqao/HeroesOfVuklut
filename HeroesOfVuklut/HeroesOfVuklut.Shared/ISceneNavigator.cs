public interface ISceneNavigator {
  SceneManager CurrentScene { get; set; }
  void GotoScene<T>(T scene, SceneParameter<T> sceneParameter) where T : SceneManager;
}
