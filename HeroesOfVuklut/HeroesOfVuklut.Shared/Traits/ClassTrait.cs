using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Traits
{
    public class ClassTrait : ICharacterTrait, IUnitTrait
    {
        public string Name { get; set; }

        public int Strength { get; set; }
        public int Endurance { get; set; }
        public int Agility { get; set; }
        public int Wisdom { get; set; }
        public int HealthPoints { get; set; }
    }
}
