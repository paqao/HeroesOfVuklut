using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.GameDataProviders.Traits
{
    public class ClassTraitInfo : TraitInfo
    {
        public string Color { get; set; }

        public int Str { get; set; }
        public int End { get; set; }
        public int Agi { get; set; }
        public int Wis { get; set; }
        public int HP { get; set; }
    }

    public class ClassTraitsInfo
    {
        public ICollection<ClassTraitInfo> Classes { get; set; }
    }
}
