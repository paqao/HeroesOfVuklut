using System.Collections.Generic;

public class ClashState {
  public IList<ClashFaction> Factions { get; protected set; }
  public ClashMap MapClash { get; protected set; }
  
  public ClashState(){
    Factions = new List<ClashFaction>();
    MapClash = new ClashMap();
  }
}
