﻿using HeroesOfVuklut.Engine.AI;
using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Shared.Clash.MapItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash.AI
{
    [ServiceInject(typeof(ClashStateArtificialIntelligence), typeof(IArtificialIntelligence<ClashState, ClashStateArtificialDecision>))]
    class ClashStateArtificialIntelligence : IArtificialIntelligence<ClashState, ClashStateArtificialDecision>
    {
        private const int MaxSteps = 5;
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
        
        
        public void TakeActions(ClashState state, ICollection<ClashStateArtificialDecision> decisions)
        {
            int repeat = 0;
            int maxResult = Int32.MinValue;
            Dictionary<ClashStateArtificialDecision, bool> actionsDictionary = decisions.ToDictionary( d => d, d => false);
            while(repeat <= MaxSteps)
            {
                int result = Int32.MinValue;
                var newDictionary = actionsDictionary.ToDictionary(d => d.Key, d => d.Value);
                
                if(result > maxResult)
                {
                    actionsDictionary = newDictionary;
                    maxResult = result;
                }
                else
                {
                    repeat++;
                }
            }
        }

        public void PrepareAi(ClashState inputData)
        {
            var map = inputData.MapClash;

            for (int i = 0; i < map.Width; i++)
            {
                for (int j = 0; j < map.Height; j++)
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

                if(itemAsCastle.Owner == 1)
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
