public abstract class Place {
  public string Name { get; protected set; }
  
  public Place(string name){
    Name = name;
  }
  
  public virtual void Visit(){
    
  }
}
