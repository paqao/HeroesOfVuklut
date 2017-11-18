using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Context
{
    public interface IResource
    {
        int Amount { get; set; }
        int Max { get; set; }
        string Name { get; set; }
    }
}
