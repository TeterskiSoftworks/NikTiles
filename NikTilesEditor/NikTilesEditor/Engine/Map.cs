using Microsoft.Xna.Framework.Graphics;

namespace NikTiles.Engine {

    public class Map {

        #region  Declarations
        private Tile[,] tiles;
        private int Y, X;
        #endregion

        public Map(int width, int height) {
            Y = width;
            X = height;
            tiles = new Tile[Y, X];
            for (int y = 0; y < Y; y++) {
                for (int x = 0; x < X; x++) {
                    tiles[y, x] = new Tile(y, x);
                }
            }

        }

        public int Width() { return X; }
        public int Height() { return Y; }

        /// <summary>
        /// Returns the tile on the map at the given x and y coordinates.
        /// </summary>
        public Tile TileAt(int x, int y) { return tiles[y, x]; }

        public Tile TileAt(int[] coord) { return tiles[coord[1], coord[0]]; }

        /// <summary>
        /// Draws the area of the map visible on the screen.
        /// </summary>
        /// <param name="width">Width of the view window.</param>
        /// <param name="height">Height of the view window.</param>
        public void Draw(SpriteBatch spriteBatch, int width, int height) {
            for (    int y = Camera.GetY()-1; y < height  / (Tile.Height() * Camera.GetZoomY()) + Camera.GetY() + 1 && y < Y; y++) {
                for (int x = Camera.GetX()-1; x < 2*width / (Tile.Width()  * Camera.GetZoomX()) + Camera.GetX() + 1 && x < X; x++) {            
                    if (y != -1 && x != -1)tiles[y, x].Draw(spriteBatch);
                }
            }
        }

    }
}