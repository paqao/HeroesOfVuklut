using HeroesOfVuklut.Shared;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfVuklut.Windows
{
    public class GameConfiguration : IGameConfiguration
    {
        public ICollection<IGameMapConfiguration> Maps { get { return MapConf.Select(m => (IGameMapConfiguration) m).ToList(); } }

        public ICollection<GameMapConfiguration> MapConf { get; set; }

        public ICollection<IGameLanguageConfiguration> Languages { get { return LangConf.Select(m => (IGameLanguageConfiguration)m).ToList(); } }

        public ICollection<GameLanguageConfiguration> LangConf { get; set; }
    }

    public class GameMapConfiguration : IGameMapConfiguration
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int Id { get; set; }
    }

    public class GameLanguageConfiguration : IGameLanguageConfiguration
    {
        public string English { get; set; }

        public string Origin { get; set; }

        public int Id { get; set; }
    }
}
