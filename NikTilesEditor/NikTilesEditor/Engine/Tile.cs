using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NikTiles.Editor;
using System.Collections.Generic;

namespace NikTiles.Engine {
    public class Tile {


        #region Static

        #region  Declarations
        private static int width = 64, height = 32;
        public static bool viewGrid = false;
        #endregion


        /// <summary> Returns the width the game tiles. </summary>
        public static int Width { get { return width; } }
        /// <summary> Returns the height the game tiles. </summary>
        public static int Height{ get { return height; } }

        #endregion

        #region Declarations
        private Rectangle rectangle = new Rectangle(0, 0, Tile.Width, Tile.Height);
        private int y, x;
        private bool selected = false;
        private bool debug = false;
        #endregion

        public Tile(int x, int y) {
            this.y = y;
            this.x = x;
            if (x % 2 != 0)
                rectangle = new Rectangle(x * Tile.Width / 2, y * Tile.Height + Tile.Height / 2, Tile.Width, Tile.Height);
            else
                rectangle = new Rectangle(Tile.Width / 2 * x, Tile.Height * y, Tile.Width, Tile.Height);
        }

        /// <summary> Returns the x coordinate of the tile. </summary>
        public int X { get { return x; } }
        /// <summary> Returns the y coordinate of the tile. </summary>
        public int Y { get { return y; } }


        /// <summary> Draws the tile. </summary>
        /// <param name="spriteBatch">The SpriteBatch used to draw the tile.</param>
        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Texture.floor["Grass"].DiffuseMap, rectangle, Color.White);
            if (viewGrid) spriteBatch.Draw(Texture.grid,      rectangle, Color.Black*0.5f);
            if (selected) spriteBatch.Draw(Texture.selection, rectangle, Color.Aqua * 0.5f);
            if (debug)    spriteBatch.Draw(Texture.grid, rectangle, Color.Red * 0.5f);
        }

        /// <summary> Selects/deselects the tile based on Selector. </summary>
        public void Select() {
            selected = !Selector.Deselect();
        }

        /// <summary> Sets the tile selection. </summary>
        public void Select(bool select) {
            selected = select;
        }

        /// <summary> Inverts the tile's selection value. </summary>
        public void InverseSelection() {
            selected = !selected;
        }

        /// <summary> A debug function which can be changed and used for any debugging needs. </summary>
        public void Debug() {
            debug = true;
        }

    }
}