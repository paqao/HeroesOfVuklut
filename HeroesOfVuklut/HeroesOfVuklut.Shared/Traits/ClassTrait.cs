using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Traits
{
    public class ClassTrait : ICharacterTrait, IUnitTrait
    {
        public string Name { get; set; }
        
    }
}
