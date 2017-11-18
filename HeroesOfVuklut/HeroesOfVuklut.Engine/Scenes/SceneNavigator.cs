using HeroesOfVuklut.Engine.DI;
using System;

namespace HeroesOfVuklut.Engine.Scenes
{
    [ServiceInject(typeof(SceneNavigator), typeof(ISceneNavigator))]
    public class SceneNavigator : ISceneNavigator
    {
        private readonly IContainerSystem _containerSystem;

        public SceneManager CurrentScene { get; set; }
        public SceneTree Scenes { get; set; }

        public SceneNavigator(IContainerSystem containerSystem)
        {
            Scenes = new SceneTree();
            _containerSystem = containerSystem;
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
