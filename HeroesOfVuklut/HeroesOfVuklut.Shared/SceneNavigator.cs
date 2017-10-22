using System;

public class SceneNavigator : ISceneNavigator {
    public IScene CurrentScene { get; set; }
    public SceneTree Scenes { get; set; }

    public SceneNavigator()
    {
        Scenes = new SceneTree();
    }

    public void CanNavigateTo<T>(T scene) where T : SceneManager<T>, IScene
    {
        throw new NotImplementedException();
    }

    public void GotoScene<T, U>(T scene, SceneManager<T>.SceneParameter<U> sceneParameter)
        where T : SceneManager<T>, IScene
        where U : T
    {

    }
}
