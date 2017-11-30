using HeroesOfVuklut.Engine.Game;
using HeroesOfVuklut.Shared.Units;
using System.Collections.Generic;

namespace HeroesOfVuklut.Shared
{
    public class GameData : IGameEntity
    {
        public Castle Castle { get; set; }
        public IList<Hero> Heroes { get; }
        public ICollection<FactionAspect> Factions { get; }
        public ICollection<UnitDefinition> UnitDefinitions { get; }

        public GameData()
        {
            Heroes = new List<Hero>();
            Factions = new List<FactionAspect>();
            UnitDefinitions = new List<UnitDefinition>();
        }

        public void Clear()
        {
            Castle = new Castle();
            Heroes.Clear();
            UnitDefinitions.Clear();
            Factions.Clear();
        }
    }

}
