public class ClashTile {
  public int X { get; private set; }
  public int Y { get; private set; }
 
    public int GroundId { get; private set; }

    public bool Hover { get; set; }

  public ClashTile(int x, int y, int groundId) {
    X = x;
    Y = y;
        GroundId = groundId;
  }
}
