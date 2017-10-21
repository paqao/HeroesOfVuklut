public class ClashUnit {
  public bool IsAlive {
    get {
      return HealthPoints > 0;
    }
  }
  public int HealthPoints { get; set; }
  public int MaxHealthPoints { get; set; }
  
  public UnitBase Template { get; set; }
  
}
