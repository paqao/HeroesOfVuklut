using HeroesOfVuklut.Engine.Scenes;

namespace HeroesOfVuklut.Engine.Game
{
    public class GameManager
    {
        private readonly GameEntity _game;
        private readonly IGameSettings _settings;
        private readonly ISceneNavigator _sceneNavigator;

        public GameManager(GameEntity game, IGameSettings settings, ISceneNavigator sceneNavigator)
        {
            _game = game;
            _settings = settings;
            _sceneNavigator = sceneNavigator;
        }

    }
}
