using HeroesOfVuklut.Engine.AI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash.AI
{
    public class ClashStateArtificialDecision : IArtificialDecision<ClashState>
    {
        public int Cost { get; }

        public void TakeAction(ClashState state)
        {
            throw new NotImplementedException();
        }
    }
}
