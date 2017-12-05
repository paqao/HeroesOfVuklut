using HeroesOfVuklut.Engine.Scenes;
using System.Collections.Generic;

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

        public abstract void SaveGame(string filename);

        public abstract ICollection<string> GetSavedGames();

        public virtual void LoadGameData()
        {

        }
    }
}
