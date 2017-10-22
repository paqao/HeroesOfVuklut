public interface ISceneNavigator {
    IScene CurrentScene { get; set; }
    void GotoScene<T,U>(T scene, SceneManager<T>.SceneParameter<U> sceneParameter) where T : SceneManager<T>, IScene
        where U : T;

    void CanNavigateTo<T>(T scene) where T : SceneManager<T>, IScene;

    SceneTree Scenes { get; set; }


}

public class SceneTree
{

    public IScene DefaultScene { get; private set; }

    public void AddSceneTransition(IScene defaultScene, IScene target)
    {

    }

    public void SetDefault(IScene defaultScene)
    {
        DefaultScene = defaultScene;
    }
}
