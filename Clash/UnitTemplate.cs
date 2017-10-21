public class UnitTemplate {
  public readonly UnitBase Unit { get; protected set; }
  public int AvailableUnits { get; protected set; } 
  
  public UnitTemplate(UnitBase unit, int availableUnits){
    AvailableUnits = availableUnits;
    Unit = unit;
  }
  
  public ClashUnit CreateUnit(){
    if(AvailableUnits == 0)
      return null;
    
    AvailableUnits--;
    
    return new ClashUnit {
      Template = Unit 
    };
  }
}
