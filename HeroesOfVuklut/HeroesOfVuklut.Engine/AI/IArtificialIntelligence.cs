using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.AI
{
    public interface IArtificialIntelligence<in T, U> where U : IArtificialDecision<T>
    {
        ICollection<U> CalculateStep(T inputData);
        
        void TakeActions(T state, ICollection<U> decisions);

        void PrepareAi(T inputData);
    }
}
