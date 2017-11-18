using HeroesOfVuklut.Engine.AI;
using HeroesOfVuklut.Engine.DI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash.AI
{
    [ServiceInject(typeof(ClashStateArtificialIntelligence), typeof(IArtificialIntelligence<ClashState, ClashStateArtificialDecision>))]
    class ClashStateArtificialIntelligence : IArtificialIntelligence<ClashState, ClashStateArtificialDecision>
    {
        public ICollection<ClashStateArtificialDecision> CalculateStep(ClashState inputData)
        {
            var listOfDecisions = new List<ClashStateArtificialDecision>();

            return listOfDecisions;
        }
    }
}
