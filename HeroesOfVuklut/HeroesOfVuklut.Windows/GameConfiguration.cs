using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfVuklut.Windows
{
    public class GameConfiguration
    {
        public ICollection<GameMapConfiguration> Maps { get; set; }
    }

    public class GameMapConfiguration
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
