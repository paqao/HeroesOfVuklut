namespace HeroesOfVuklut.Shared
{
    public class GameManager
    {
        private readonly HeroesGame _game;
        private readonly Settings _settings;

        private readonly ISceneNavigator _sceneNavigator;

        public GameManager(HeroesGame game, Settings settings, ISceneNavigator sceneNavigator)
        {
            _game = game;
            _settings = settings;
            _sceneNavigator = sceneNavigator;
        }

    }
}

