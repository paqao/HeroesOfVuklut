public abstract class BuildingBase {
  public string Name { get; protected set; }
  public int Level { get; protected set; }
  
  public BuildingBase(string name, int level){
    Name = name;
    Level = level;
  }
  
  
}
