using System;
using System.Collections.Generic;

namespace HeroesOfVuklut.Engine.Scenes
{

    public class SceneTree
    {
        public IDictionary<Type, SceneManager> DefinedScenes { get; private set; }
        public SceneManager DefaultScene { get; private set; }

        public SceneTree()
        {
            DefinedScenes = new Dictionary<Type, SceneManager>();
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

}
