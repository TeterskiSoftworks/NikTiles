using Microsoft.Xna.Framework.Graphics;

namespace NikTiles.Engine {

    public class Map {

        #region  Declarations
        private Tile[,] tiles;
        private int y, x;
        #endregion

        public Map(int y, int x) {
            this.y = y;
            this.x = x;
            tiles = new Tile[y, x];
            for (int _y = 0; _y < y; _y++) {
                for (int _x = 0; _x < x; _x++) {
                    tiles[_y, _x] = new Tile(_y, _x);
                }
            }

        }



        public int GetX() { return x; }
        public int GetY() { return y; }


        /// <summary>
        /// Returns the tile on the map at the given x and y coordinates.
        /// </summary>
        public Tile Tile(int x, int y) { return tiles[y, x]; }

        public void Draw(SpriteBatch spriteBatch) {
            foreach(Tile tile in tiles) {
                tile.Draw(spriteBatch);
            }
        }

    }
}
