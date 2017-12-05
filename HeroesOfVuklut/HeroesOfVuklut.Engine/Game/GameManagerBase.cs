using HeroesOfVuklut.Engine.Scenes;

namespace HeroesOfVuklut.Engine.Game
{
    public abstract class GameManagerBase<T, U> 
        where T : IGameEntity
        where U : IGameSettings
    {

        public T Game { get; private set; }
        public U Settings { get; private set; }

        public GameManagerBase()
        {
        }

        public virtual void Initialize(T game, U settings)
        {
            Game = game;
            Settings = settings;
        }

        public virtual void LoadGameData()
        {

        }
    }
}
