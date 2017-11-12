using HeroesOfVuklut.Engine.Game;
using System.Collections.Generic;

namespace HeroesOfVuklut.Shared
{
    public class HeroesGame : GameEntity
    {
        public Castle Castle { get; set; }
        public IList<Hero> Heroes { get; }

        public HeroesGame()
        {
            Heroes = new List<Hero>();
        }

        public void Clear()
        {
            Castle = new Castle();
            Heroes.Clear();
        }
    }

}
