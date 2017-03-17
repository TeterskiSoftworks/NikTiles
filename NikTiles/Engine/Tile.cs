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

        public static int GetX() { return X; }
        public static int GetY() { return Y; }

        #endregion

        #region Declarations
        private Rectangle rectangle = new Rectangle(0, 0, Tile.GetX(), Tile.GetY());
        private int y,x;
        #endregion

        public Tile(int y, int x) {
            this.y = y;
            this.x = x;
            rectangle = new Rectangle(Tile.GetX()*x, Tile.GetY()*y, Tile.GetX(), Tile.GetY());
        }


        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(ContentLoader.textures["Grass"], rectangle, Color.White);
        }

    }
}
