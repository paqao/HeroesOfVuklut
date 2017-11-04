using HeroesOfVuklut.Shared.Clash.MapItems;
using System.Collections.Generic;


namespace HeroesOfVuklut.Shared.Clash
{
    public class ClashState
    {
        public IList<ClashFaction> Factions { get; protected set; }
        public ClashMap MapClash { get; protected set; }

        public ClashState()
        {
            Factions = new List<ClashFaction>();

            var playerCastle = new ClashFactionCastle
            {
            };
            var playerFaction = new ClashFaction
            {
                Castle = playerCastle,
                Aspect = new FactionAspect
                {
                    Color = Color.Red,
                    Id = 1,
                    Name = "Gracz"
                }
            };

            Factions.Add(playerFaction);

            MapClash = new ClashMap(16, 14);

            MapClash.Tiles[0][0].Item = playerCastle;
        }
    }
}
