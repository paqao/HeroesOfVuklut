using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfVuklut.Windows.Factions
{

    internal class FactionConfiguration
    {
        public ICollection<FactionInfo> Factions { get; set; }
    }

    internal class FactionInfo
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
