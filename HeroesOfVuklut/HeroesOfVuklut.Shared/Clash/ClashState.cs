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
            MapClash = new ClashMap(16, 14);

            MapClash.Tiles[0][0].Item = new ClashFactionCastle();
        }
    }
}
