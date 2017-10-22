public class ClashMap {
  public ClashTile[][] Tiles { get; private set; }
  
  public ClashMap(int w, int h){
    Tiles = new ClashTile[h][];
    for(int i=0;i<h;i++){
      Tiles[i] = new ClashTile[w];
      for(int j=0;j<w;j++){
        Tiles[i][j] = new ClashTile(i,j);
      }
    }
  }
}
