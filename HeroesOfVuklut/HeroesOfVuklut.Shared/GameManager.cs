public class GameManager {
  private readonly HeroesGame _game;
  private readonly Settings _settings;
  
  private readonly ClashManager _clashManager;
  
  public GameManager(HeroesGame game, Settings settings, ClashManager clashManager){
    _game = game;
    _settings = settings;
    _clashManager = clashManager;
  }
  
}
