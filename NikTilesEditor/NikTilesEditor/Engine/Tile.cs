using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NikTiles.Editor;
using System.Collections.Generic;

namespace NikTiles.Engine {
    public class Tile {


        #region Static

        #region  Declarations
        private static int X = 64, Y = 32;
        public static bool viewGrid = false;
        public static Dictionary<string, Texture2D> floor;
        public static Texture2D selection, grid;
        #endregion

        public static int Width() { return X; }
        public static int Height() { return Y; }

        #endregion

        #region Declarations
        private Rectangle rectangle = new Rectangle(0, 0, Tile.Width(), Tile.Height());
        private int y, x;
        private bool selected = false;
        #endregion

        public Tile(int y, int x) {
            this.y = y;
            this.x = x;
            if (x % 2 != 0)
                rectangle = new Rectangle(x * Tile.Width() / 2, y * Tile.Height() + Tile.Height() / 2, Tile.Width(), Tile.Height());
            else
                rectangle = new Rectangle(Tile.Width() / 2 * x, Tile.Height() * y, Tile.Width(), Tile.Height());
        }

        public int GetX() { return x; }
        public int GetY() { return y; }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(floor["Grass"], rectangle, Color.White);
            if (viewGrid) spriteBatch.Draw(grid,      rectangle, Color.Black*0.5f);
            if (selected) spriteBatch.Draw(selection, rectangle, Color.Aqua * 0.5f);

        }

        public void Select() {
            selected = true;
        }

        public void Deselect() {
            selected = false;
        }

        public void InverseSelection() {
            selected = !selected;
        }

    }
}