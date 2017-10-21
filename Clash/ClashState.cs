public class ClashState {
  public IList<ClashFaction> Factions { get; protected set; }
  
  public ClashState(){
    Factions = new List<ClashFaction>();
  }
}
