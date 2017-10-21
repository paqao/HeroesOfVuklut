using System.Collections.Generic;

public class ClashFaction {
  public IList<UnitTemplate> UnitTemplates { get; protected set; }
  
  public ClashFaction(){
    UnitTemplates = new List<UnitTemplate>();
  }
}
