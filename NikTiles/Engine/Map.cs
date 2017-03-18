using Microsoft.Xna.Framework.Graphics;

namespace NikTiles.Engine {

    public class Map {

        #region  Declarations
        private Tile[,] tiles;
        private int Y, X;
        #endregion

        public Map(int y, int x) {
            Y = y;
            X = x;
            tiles = new Tile[y, x];
            for (int _y = 0; _y < y; _y++) {
                for (int _x = 0; _x < x; _x++) {
                    tiles[_y, _x] = new Tile(_y, _x);
                }
            }

        }

        public int GetX() { return X; }
        public int GetY() { return Y; }

        /// <summary>
        /// Returns the tile on the map at the given x and y coordinates.
        /// </summary>
        public Tile TileAt(int x, int y) { return tiles[y, x]; }

        public void Draw(SpriteBatch spriteBatch, int width, int height) {
            
            for (int     y = Camera.GetY()-1; y < height/Tile.Height() + Camera.GetY() +1 && y<Y; y++) {
                for (int x = Camera.GetX()-1; x < 2*width/Tile.Width() + Camera.GetX() +1 && x<X; x++) {
                    if( y!=-1 && x !=-1) tiles[y, x].Draw(spriteBatch);
                }
            }
        }

    }
}
