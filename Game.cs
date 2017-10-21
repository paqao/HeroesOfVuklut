public class Game {
  public Castle Castle { get; set; }
  public IList<Hero> Heroes { get; }
  
  public Game(){
   Heroes = new List<Hero>(); 
  }
  
  public Clear() {
    Castle = new Castle(); 
    Heroes.clear();
  }
}
