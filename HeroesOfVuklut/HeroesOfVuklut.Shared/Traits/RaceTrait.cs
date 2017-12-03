using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Traits
{
    public class RaceTrait : ICharacterTrait, IUnitTrait
    {
        public string Name { get; set; }
    }
}
