using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikTiles.Engine {
    public class Tile {


        #region Static

        #region  Declarations
        private static int X = 64, Y = 32;
        #endregion

        public static int Width() { return X; }
        public static int Height() { return Y; }

        #endregion

        #region Declarations
        private Rectangle rectangle = new Rectangle(0, 0, Tile.Width(), Tile.Height());
        private int y,x;
        #endregion

        public Tile(int y, int x) {
            this.y = y;
            this.x = x;
            if (x%2!=0)
                rectangle = new Rectangle(x * Tile.Width()/2, y * Tile.Height() + Tile.Height()/2, Tile.Width(), Tile.Height());
            else
                rectangle = new Rectangle(Tile.Width()/2 * x, Tile.Height() * y, Tile.Width(), Tile.Height());
        }

        public int GetX() { return x; }
        public int GetY() { return y; }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(ContentLoader.textures["Grass"], rectangle, Color.White);
        }



    }
}
