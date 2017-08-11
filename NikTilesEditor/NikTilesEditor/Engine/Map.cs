using Microsoft.Xna.Framework.Graphics;

namespace NikTiles.Engine {

    public class Map {

        #region  Declarations
        private Tile[,] tiles;
        private readonly int width, height;
        #endregion


        public Map(int width, int height) {
            this.width = width;
            this.height = height;
            tiles = new Tile[width, height];
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    tiles[x, y] = new Tile(x, y);
                }
            }

        }

        public int Width { get { return width; } }
        public int Height { get { return height; } }

        /// <summary>Returns the tile on the map at the given coordinates. </summary>
        /// <param name="x">The x coordinate of the tile.</param>
        /// <param name="y">The y coordinate of the tile.</param>
        public Tile TileAt(int x, int y) { return tiles[x, y]; }

        /// <param name="coord">The coordinate pair of the tile.</param>
        public Tile TileAt(int[] coord) { return tiles[coord[0], coord[1]]; }

        public void ReplaceFloorMaterial(string original, string replacer) {
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    if(tiles[x, y].Material == original) tiles[x, y].Material = replacer;
                }
            }
        }


        /// <summary> Draws the area of the map visible on the screen. </summary>
        /// <param name="spriteBatch">The SpriteBatch used to draw the map.</param>
        /// <param name="width">Width of the view window.</param>
        /// <param name="height">Height of the view window.</param>
        public void Draw(SpriteBatch spriteBatch, int width, int height) {
            for (int y = Camera.Y; y < height  / (Tile.Height * Camera.ZoomY) + Camera.Y + 1 && y < Width; y++) {

                //Draws the even x-tiles of the y-row first, because they are further back, and then draws the odd ones.
                for (int x = Camera.X; x < 2 * width / (Tile.Width * Camera.ZoomX) + Camera.X + 1 && x < Height; x += 2) {
                    if (y >= 0 && x >= 0) tiles[x, y].Draw(spriteBatch);
                }
                for (int x = Camera.X + 1; x < 2 * width / (Tile.Width * Camera.ZoomX) + Camera.X + 1 && x < Height; x += 2) {
                    if (y >= 0 && x >= 0) tiles[x, y].Draw(spriteBatch);
                }
            }
        }

    }
}