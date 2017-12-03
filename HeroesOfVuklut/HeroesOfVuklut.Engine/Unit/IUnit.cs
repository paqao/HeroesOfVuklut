using HeroesOfVuklut.Engine.Traits;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Unit
{
    public interface IUnit
    {
        string Name { get; set; }

        ICollection<ITrait> Traits { get; set; }
    }
}
