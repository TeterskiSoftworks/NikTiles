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
        private string material = "Empty";
        #endregion


        /// <summary> Returns the width the game tiles. </summary>
        public static int Width { get { return width; } }
        /// <summary> Returns the height the game tiles. </summary>
        public static int Height { get { return height; } }

        #endregion

        #region Declarations
        private Vector2 coordinate = new Vector2();
        private Vector2[] pixelPosition = new Vector2[3];
        private bool[] selected = new bool[]{ false,false,false};
        private const int FLOOR = 0, LEFTWALL = 1, RIGHTWALL = 2;

        private bool debug = false;
        #endregion

        public Tile(int x, int y) {
            coordinate = new Vector2(x, y);
            if (x % 2 == 1)
                Position = new Vector2(x * Width / 2, y * Height + Height/2);
            else
                Position = new Vector2(x * Width / 2, y * Height);
        }

        /// <summary> Returns the x coordinate of the tile. </summary>
        public int X { get { return (int)coordinate.X; } }
        /// <summary> Returns the y coordinate of the tile. </summary>
        public int Y { get { return (int)coordinate.Y; } }

        /// <summary> Sets or returns the pixel position of the tile in vector form. </summary>
        private Vector2 Position {
            set {
                pixelPosition[FLOOR] = value;
                pixelPosition[LEFTWALL]  = new Vector2(Position.X, Position.Y - Height +1);
                pixelPosition[RIGHTWALL] = new Vector2(Position.X + Width / 2, Position.Y - Height + 1);
            } get { return pixelPosition[FLOOR]; }
        }

        #region Draw

        /// <summary> Draws the tile. </summary>
        /// <param name="spriteBatch">The SpriteBatch used to draw the tile.</param>
        public void Draw(SpriteBatch spriteBatch) {
            DrawFloor(spriteBatch);
            DrawWall(spriteBatch);
        }

        private void DrawFloor(SpriteBatch spriteBatch) {
            spriteBatch.Draw( Engine.Material.floor[material].DiffuseMap, pixelPosition[FLOOR], Color.White);
            if (viewGrid)        spriteBatch.Draw(Texture.grid,           pixelPosition[FLOOR], Color.Black * 0.5f);
            if (selected[FLOOR]) spriteBatch.Draw(Texture.floorSelection, pixelPosition[FLOOR], Color.Aqua  * 0.5f);
            if (debug)           spriteBatch.Draw(Texture.floorSelection, pixelPosition[FLOOR], Color.Gray  * 0.5f);
        }

        private void DrawWall(SpriteBatch spriteBatch) {
            if (selected[LEFTWALL])  spriteBatch.Draw(Texture.wallSelection, pixelPosition[LEFTWALL] ,       Color.Red * 0.5f);
            if (selected[RIGHTWALL]) spriteBatch.Draw(Texture.wallSelection, pixelPosition[RIGHTWALL], null, Color.Green*0.5f, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 1);
        }
        #endregion


        #region Selection

        /// <summary> Selects/deselects the tile's floor. </summary>
        public void Select(bool select) {
            SelectFloor(select);
            SelectWalls(select);
        }

        public void SelectFloor(bool select) {
            selected[FLOOR] = select;
        }

        public void SelectWalls(bool select) {
            SelectWall(select, false);
            SelectWall(select, true);
        }

        public void SelectWall(bool select, bool right) {
            if (right) selected[RIGHTWALL] = select;
            else        selected[LEFTWALL] = select;
        }

        public bool Selected { get { return selected[FLOOR];  } }

        /// <summary> Inverts the tile's selection value. </summary>
        public void InverseSelection() {
            selected[FLOOR] = !selected[FLOOR];
        }

        #endregion

        public string Material { get { return material; } set { material = value; }}

        /// <summary> A debug function which can be changed and used for any debugging needs. </summary>
        public void Debug(bool val) {
            debug = val;
        }

    }
}