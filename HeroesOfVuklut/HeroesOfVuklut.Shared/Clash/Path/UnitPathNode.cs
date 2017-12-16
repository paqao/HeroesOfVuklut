namespace HeroesOfVuklut.Shared.Clash.Path
{
    public class UnitPathNode {
        
        public int NodeId { get; set; }
        public int Cost { get; set; }
        public UnitPathNode Precessor { get; set; }
    }
}