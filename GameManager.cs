public class GameManager {
  private readonly Game _game;
  private readonly Settings _settings;
  
  private readonly ClashManager _clashManager;
  
  public GameManager(Game game, Settings settings, ClashManager clashManager){
    _game = game;
    _settings = settings;
    _clashManager = clashManager;
  }
  
}
