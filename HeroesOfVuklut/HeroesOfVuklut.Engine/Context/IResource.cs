using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Context
{
    public interface IResource
    {
        decimal Amount { get; set; }
        decimal Max { get; set; }
        string Name { get; set; }
    }
}
