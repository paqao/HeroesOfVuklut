using HeroesOfVuklut.Engine.AI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Scenes
{
    public interface ISceneIntelligence<T,U> where U : IArtificialDecision<T>
    {
        IArtificialIntelligence<T, U> IAi { get; }

        ICollection<U> Calculate();
    }
}
