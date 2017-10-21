using System.Collections.Generic;

public class WorldMap {
  public Castle OwnCastle { get; set; }
  public IList<Place> Places { get; }
  
  public WorldMap(){
    Places = new List<Place>();
  }
}
