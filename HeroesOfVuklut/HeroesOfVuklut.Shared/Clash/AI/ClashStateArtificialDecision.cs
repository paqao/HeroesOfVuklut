using HeroesOfVuklut.Engine.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash.AI
{
    public class ClashStateArtificialDecision : IArtificialDecision<ClashState>
    {
        public enum ClashStateDecisionType
        {
            Wait,
            UpgradeItem,
            BuildItem
        }

        public int Cost { get; }

        public ClashStateDecisionType Decision { get; set; }
        public int DecisionParameter { get; set; }

        public void TakeAction(ClashState state)
        {
            switch (Decision)
            {
                case ClashStateDecisionType.Wait:
                    break;
                case ClashStateDecisionType.UpgradeItem:
                    {
                        var item = state.MapClash.Buildings[DecisionParameter];
                        var faction = state.Factions.First(f => f.Aspect.Id == item.Owner);

                        item.Upgrade(faction);

                        break;
                    }
                default:
                    break;
            }
        }

        
    }
}
