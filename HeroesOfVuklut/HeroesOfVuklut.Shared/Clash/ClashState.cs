using HeroesOfVuklut.Shared.Clash.MapItems;
using System.Collections.Generic;


namespace HeroesOfVuklut.Shared.Clash
{
    public class ClashState
    {
        public IList<ClashFaction> Factions { get; protected set; }
        public ClashMap MapClash { get; set; }

        public ClashState()
        {
            Factions = new List<ClashFaction>();

            var playerFaction = new ClashFaction
            {
                Aspect = new FactionAspect
                {
                    Color = Color.Red,
                    Id = 1,
                    Name = "Gracz"
                }
            };

            Factions.Add(playerFaction);
            
        }
    }
}
