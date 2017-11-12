using System;

namespace HeroesOfVuklut.Engine.Scenes
{
    public interface ISceneNavigator
    {
        SceneManager CurrentScene { get; set; }
        void GotoScene<T, U>(Type scene, SceneManager<T>.SceneParameter<U> sceneParameter) where T : SceneManager<T>
            where U : T;

        void CanNavigateTo<T>(T scene) where T : SceneManager<T>;

        SceneTree Scenes { get; set; }

    }

}
