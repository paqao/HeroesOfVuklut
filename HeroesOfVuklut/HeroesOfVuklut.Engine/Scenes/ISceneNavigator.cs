using System;

namespace HeroesOfVuklut.Engine.Scenes
{
    public interface ISceneNavigator
    {
        SceneManager CurrentScene { get; set; }
        void GotoScene(Type scene, SceneManager.SceneParameter sceneParameter);

        void CanNavigateTo<T>(T scene) where T : SceneManager<T>;

        SceneTree Scenes { get; set; }

    }

}
