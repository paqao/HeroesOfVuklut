using HeroesOfVuklut.Engine.AI;
using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Shared.Clash.MapItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash.AI
{
    [ServiceInject(typeof(ClashStateArtificialIntelligence), typeof(IArtificialIntelligence<ClashState, ClashStateArtificialDecision>))]
    class ClashStateArtificialIntelligence : IArtificialIntelligence<ClashState, ClashStateArtificialDecision>
    {
        private ClashFactionCastle _castle = null;
        private List<ClashFactionCastle> _otherCastles = new List<ClashFactionCastle>();

        public ICollection<ClashStateArtificialDecision> CalculateStep(ClashState inputData)
        {
            var listOfDecisions = new List<ClashStateArtificialDecision>();
            var map = inputData.MapClash;

            // upgradeCastles 
            foreach (var item in _otherCastles)
            {
                if(item.Level < _castle.Level)
                {
                    ClashStateArtificialDecision newDecision = new ClashStateArtificialDecision();
                    
                    newDecision.Decision = ClashStateArtificialDecision.ClashStateDecisionType.UpgradeItem;
                    newDecision.DecisionParameter = item.Id;

                    listOfDecisions.Add(newDecision);
                }
            }

            return listOfDecisions;
        }

        public void PrepareAi(ClashState inputData)
        {
            var map = inputData.MapClash;

            for (int i = 0; i < map.Width; i++)
            {
                for (int j = 0; j < map.Heigth; j++)
                {
                    var tile = map.Tiles[j][i];
                    var item = tile.Item;

                    if (item != null)
                    {
                        ProcessItem(item);
                    }
                }
            }
        }

        private void ProcessItem(ClashTileItem item)
        {
            if(item is ClashFactionCastle)
            {
                var itemAsCastle = item as ClashFactionCastle;

                if(itemAsCastle.Owner == 0)
                {
                    _castle = itemAsCastle;
                }
                else
                {
                    _otherCastles.Add(itemAsCastle);
                }
            }
        }
    }
}
