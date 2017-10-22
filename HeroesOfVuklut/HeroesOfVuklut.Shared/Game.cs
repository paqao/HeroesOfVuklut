using System.Collections.Generic;

public class HeroesGame {
  public Castle Castle { get; set; }
  public IList<Hero> Heroes { get; }
  
  public HeroesGame(){
   Heroes = new List<Hero>(); 
  }
  
  public void Clear() {
    Castle = new Castle(); 
    Heroes.Clear();
  }
}