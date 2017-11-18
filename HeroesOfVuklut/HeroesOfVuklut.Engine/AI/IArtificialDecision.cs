using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.AI
{
    public interface IArtificialDecision<T>
    {
        int Cost { get; }

        void TakeAction(T context);
    }
}
