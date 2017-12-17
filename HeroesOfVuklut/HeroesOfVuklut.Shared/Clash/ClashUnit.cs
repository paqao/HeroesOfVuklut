using HeroesOfVuklut.Shared.Clash.Path;

namespace HeroesOfVuklut.Shared.Clash
{

    public class ClashUnit
    {
        public bool IsAlive
        {
            get
            {
                return HealthPoints > 0;
            }
        }

        public int HealthPoints { get; set; }
        public int MaxHealthPoints { get; set; }

        public UnitBase Template { get; set; }
        public UnitPath Path { get; internal set; }

        public decimal X { get; set; }
        public decimal Y { get; set; }
    }

}