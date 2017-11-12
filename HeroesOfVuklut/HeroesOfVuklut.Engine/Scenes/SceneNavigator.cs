using System;

namespace HeroesOfVuklut.Engine.Scenes
{
    public class SceneNavigator : ISceneNavigator
    {
        public SceneManager CurrentScene { get; set; }
        public SceneTree Scenes { get; set; }

        public SceneNavigator()
        {
            Scenes = new SceneTree();
        }

        public void CanNavigateTo<T>(T scene) where T : SceneManager<T>
        {
            throw new NotImplementedException();
        }

        public void GotoScene<T, U>(Type scene, SceneManager<T>.SceneParameter<U> sceneParameter)
            where T : SceneManager<T>
            where U : T
        {
            var newScene = Scenes.DefinedScenes[scene];

            CurrentScene = newScene;

            CurrentScene.BeginScene(sceneParameter);
        }
    }

}
