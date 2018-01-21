namespace HeroesOfVuklut.Shared.Clash
{

    public class UnitTemplate
    {
        public UnitBase Unit { get; protected set; }
        public ClashFaction Faction { get; set; }
        public int AvailableUnits { get; protected set; }

        public UnitTemplate(UnitBase unit, ClashFaction faction, int availableUnits)
        {
            AvailableUnits = availableUnits;
            Unit = unit;
            Faction = faction;
        }

        public ClashUnit CreateUnit()
        {
            if (AvailableUnits == 0)
                return null;

            AvailableUnits--;

            return new ClashUnit
            {
                Template = Unit
            };
        }
    }

}