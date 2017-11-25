using HeroesOfVuklut.Engine.Game;
using System.Collections.Generic;

namespace HeroesOfVuklut.Shared
{
    public class GameData : IGameEntity
    {
        public Castle Castle { get; set; }
        public IList<Hero> Heroes { get; }
        public ICollection<FactionAspect> Factions { get; }
        

        public GameData()
        {
            Heroes = new List<Hero>();
            Factions = new List<FactionAspect>();
        }

        public void Clear()
        {
            Castle = new Castle();
            Heroes.Clear();
        }
    }

}
