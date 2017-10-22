using System;
using System.Collections.Generic;

public interface ISceneNavigator {
    SceneManager CurrentScene { get; set; }
    void GotoScene<T,U>(Type scene, SceneManager<T>.SceneParameter<U> sceneParameter) where T : SceneManager<T>
        where U : T;

    void CanNavigateTo<T>(T scene) where T : SceneManager<T>;

    SceneTree Scenes { get; set; }
    
}

public class SceneTree
{
    public IDictionary<Type, SceneManager> DefinedScenes { get; private set; }
    public SceneManager DefaultScene { get; private set; }

    public SceneTree()
    {
        DefinedScenes = new Dictionary<Type,SceneManager>();
    }

    public void AddScene(SceneManager scene)
    {
        DefinedScenes.Add(scene.GetSceneType(), scene);
    }

    public void AddSceneTransition(SceneManager defaultScene, SceneManager target)
    {

    }

    public void SetDefault(SceneManager defaultScene)
    {
        DefaultScene = defaultScene;
    }
}
