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
        public static int Height{ get { return height; } }

        #endregion

        #region Declarations
        private Vector2 leftWallPosition  = new Vector2(),
                        rightWallPosition = new Vector2(),
                        floorPosition     = new Vector2();
        private bool floorSelected     = false,
                     leftWallSelected  = false,
                     rightWallSelected = false;
        private bool debug = false;
        #endregion

        public Tile(int x, int y) {
            if (x % 2 == 1)
                Position = new Vector2(x * Width / 2, y * Height + Height/2);
            else
                Position = new Vector2(x * Width / 2, y * Height);
        }

        /// <summary> Returns the x coordinate of the tile. </summary>
        public int X { get { return (int)Position.X; } }
        /// <summary> Returns the y coordinate of the tile. </summary>
        public int Y { get { return (int)Position.Y; } }

        /// <summary> Returns the position of the tile in vector form. </summary>
        public Vector2 Position {
            set {
                floorPosition = value;
                leftWallPosition  = new Vector2(Position.X, Position.Y - Height +1);
                rightWallPosition = new Vector2(Position.X + Width / 2, Position.Y - Height + 1);
            } get { return floorPosition; }
        }

        /// <summary> Draws the tile. </summary>
        /// <param name="spriteBatch">The SpriteBatch used to draw the tile.</param>
        public void Draw(SpriteBatch spriteBatch) {
            DrawFloor(spriteBatch);
            DrawWall(spriteBatch);
        }

        public void DrawFloor(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Engine.Material.floor[material].DiffuseMap, floorPosition, Color.White);
            if (viewGrid)      spriteBatch.Draw(Texture.grid,            floorPosition, Color.Black * 0.5f);
            if (floorSelected) spriteBatch.Draw(Texture.floorSelection,  floorPosition, Color.Aqua  * 0.5f);
        }

        public void DrawWall(SpriteBatch spriteBatch) {
            if (leftWallSelected ) spriteBatch.Draw(Texture.wallSelection, leftWallPosition,       Color.Aqua * 0.5f);
            if (rightWallSelected) spriteBatch.Draw(Texture.wallSelection, rightWallPosition,null, Color.Aqua * 0.5f, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 1);
            if (debug)             spriteBatch.Draw(Texture.wall,          leftWallPosition,       Color.Red  * 0.5f);
        }


        /// <summary> Selects/deselects the tile's floor. </summary>
        public void SelectFloor() {
            floorSelected = !Selector.Deselect;
        }

        public void SelectWall(bool right) {
            if (right) rightWallSelected = !Selector.Deselect;
            else       leftWallSelected  = !Selector.Deselect;
        }

        public bool Selected {
            get { return floorSelected; }
            set { floorSelected = value; }
        }

        /// <summary> Inverts the tile's selection value. </summary>
        public void InverseSelection() {
            floorSelected = !floorSelected;
        }

        public string Material { get { return material; } set { material = value; }}

        /// <summary> A debug function which can be changed and used for any debugging needs. </summary>
        public void Debug() {
            debug = true;
        }


    }
}