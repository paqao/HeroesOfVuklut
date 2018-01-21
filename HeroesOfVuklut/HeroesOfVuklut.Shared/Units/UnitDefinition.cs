using HeroesOfVuklut.Engine.Unit;
using HeroesOfVuklut.Shared.Traits;
using System;
using System.Collections.Generic;
using System.Text;
using HeroesOfVuklut.Engine.Traits;

namespace HeroesOfVuklut.Shared.Units
{
    public class UnitDefinition : IUnit
    {
        public string DefinitionName { get; set; }
        public int FactionId { get; set; }
        public int DefinitionId { get; set; }

        public RaceTrait Race { get; set; }
        public ClassTrait CharacterClass { get; set; }
        public string Name { get; set; }
        public bool CanBeUsed { get
            {
                return CharacterClass != null;
            }
        }
        public ICollection<ITrait> Traits { get; set; }
    }
}
