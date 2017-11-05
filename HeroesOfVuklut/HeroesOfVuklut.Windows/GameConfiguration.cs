using HeroesOfVuklut.Shared;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfVuklut.Windows
{
    public class GameConfiguration : IGameConfiguration
    {
        public ICollection<IGameMapConfiguration> Maps { get { return MapConf.Select(m => (IGameMapConfiguration) m).ToList(); } }

        public ICollection<GameMapConfiguration> MapConf { get; set; }
    }

    public class GameMapConfiguration : IGameMapConfiguration
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int Id { get; set; }
    }
}
