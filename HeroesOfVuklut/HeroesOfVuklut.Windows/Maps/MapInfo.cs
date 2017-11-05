using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfVuklut.Windows.Maps
{
    public class MapInfo
    {
        public string Name
        {
            get; set;
        }

        public int Id { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
    }
}
