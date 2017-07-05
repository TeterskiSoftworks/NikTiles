using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;
using NikTiles.Editor.Forms;

namespace NikTiles.Engine {
    public static class Cursor {

        #region Fields
        private static Vector2 position = new Vector2(1, 0);
        private static Rectangle rectangle = new Rectangle(0, 0, 0, 0);

        private static Texture2D cursorFloor, cursorWall;
        private static Color[] mouseMap;
        private static Color mouseMapPosition = new Color();
        private static bool offGrid = false;

        public enum Modes {
            Floor, Wall
        }

        private static Modes currentMode = Modes.Floor;
        #endregion

        public static Modes Mode{ set { currentMode = value; } get { return currentMode; } }

        public static int X { get {
                switch (currentMode) {
                    case Modes.Floor: return FloorCursor.X;
                    case Modes.Wall:  return WallCursor.X;
                }
                return -1;
            }
        }

        public static int Y {get {
                switch (currentMode) {
                    case Modes.Floor:    return FloorCursor.Y;
                    case Modes.Wall:     return WallCursor.Y;
                }
                return -1;
            }
        }

        public static void SetCursor(MouseEventArgs mouse) {
            switch (currentMode){
                case Modes.Floor:
                    FloorCursor.SetCursor(mouse);
                    break;
                case Modes.Wall:
                    break;
            }

        }

        public static void Draw(SpriteBatch spriteBatch) {
            switch (currentMode) {
                case Modes.Floor:
                    FloorCursor.Draw(spriteBatch);
                    break;
                case Modes.Wall:
                    break;
            }
        }

        public static void LoadCursorTextures(Color[] mouseMap, Texture2D cursorTexture) {
            Cursor.mouseMap = mouseMap;
            Cursor.cursorFloor = cursorTexture;
            CreateRectangle();
        }

        public static void CreateRectangle() {
            switch (currentMode) {
                case Modes.Floor:
                    FloorCursor.CreateRectangle();
                    break;
                case Modes.Wall:
                    break;
            }
        }

        private static class FloorCursor {

            /// <summary>
            /// Translates or moves the camera.
            /// </summary>
            /// <param name="y">Change in Y.</param>
            /// <param name="x">Change in X.</param>
            public static void Translate(int y, int x) {
                position.X += x; position.Y += x;
                CreateRectangle();
            }

            /// <summary>
            /// Sets the cursor on the map based on user mouse movement.
            /// </summary>
            public static void SetCursor(MouseEventArgs mouse) {

                position.X = (int)((2 * mouse.X - Tile.Width * Camera.ZoomX) / (Tile.Width * Camera.ZoomX));
                if (position.X % 2 != 0) position.X++;
                position.Y = (int)(mouse.Y / (Tile.Height * Camera.ZoomY));

                OffGridCheck1(mouse);

                if (!offGrid) {

                    //Consider having the colors be dynamically be selected from the 4 corners
                    //of the mouseMap.
                    //  -how would non-standard/custom mousemaps work into this, e.g. hexagons?

                    mouseMapPosition = mouseMap[Tile.Width *
                       (int)(mouse.Y / Camera.ZoomY - Y * Tile.Height) * cursorFloor.Height / Tile.Height +
                       (int)(mouse.X / Camera.ZoomX - X * Tile.Width / 2) * cursorFloor.Width / Tile.Width];

                    if (mouseMapPosition == Color.Red) {
                        position.X--;
                        position.Y--;
                    } else if (mouseMapPosition == Color.Yellow) {
                        position.X++;
                        position.Y--;
                    } else if (mouseMapPosition == Color.Green) {
                        position.X--;
                    } else if (mouseMapPosition == Color.Blue) {
                        position.X++;
                    }
                    OffGridCheck2();
                    CreateRectangle();
                }
            }

            /// <summary>
            /// Creates/recreates the rectangle used by XNA to draw the cursor.
            /// This visually chagned the location of the cursor on the screen.
            /// </summary>
            public static void CreateRectangle() {
                if (X % 2 != 0)
                    rectangle = new Rectangle(X * Tile.Width / 2, Y * Tile.Height + Tile.Height / 2, Tile.Width, Tile.Height);
                else rectangle = new Rectangle(X * Tile.Width / 2, Y * Tile.Height, Tile.Width, Tile.Height);
            }

            /// <summary>
            /// The first check to see if the cursor is out of bounds of the map, using mouse poistion.
            /// </summary>
            private static void OffGridCheck1(MouseEventArgs mouse) {
                offGrid = false;
                if ((int)(mouse.X / Camera.ZoomX - position.X * Tile.Width / 2 + Camera.GetPixelsX() / Camera.ZoomX) * cursorFloor.Width / Tile.Width < 0)
                    offGrid = true;
                else if ((int)(mouse.Y / Camera.ZoomY - position.Y * Tile.Height + Camera.GetPixelsY() / Camera.ZoomY) * cursorFloor.Height / Tile.Height < 0)
                    offGrid = true;
                else if (position.X > MapDisplay.CurrentMap.Width - 1) offGrid = true;
                else if (position.Y > MapDisplay.CurrentMap.Height - 1) offGrid = true;
            }


            /// <summary>
            /// The second check to see if the mouse hasen't been moved out of the map bounds.
            /// It checks too see if the cursor is still inbounds once its location has been
            /// transformed by the mouse map.
            /// </summary>
            private static void OffGridCheck2() {
                offGrid = false;
                if (position.X < 0) offGrid = true;
                if (position.Y < 0 && position.X % 2 != 0)
                    offGrid = true;
                else if (position.X > MapDisplay.CurrentMap.Width - 1) offGrid = true;
                else if (position.Y > MapDisplay.CurrentMap.Height - 1) offGrid = true;
            }


            public static Vector2 GetPosition() {
                return position;
            }

            public static int X { get { return (int)position.X; } }

            public static int Y { get { return (int)position.Y; } }

            public static void Draw(SpriteBatch spriteBatch) {
                if (!offGrid) spriteBatch.Draw(cursorFloor, rectangle, Color.White);
            }

        }

        private static class WallCursor {

            public static int X { get { return (int)position.X; } }
            public static int Y { get { return (int)position.Y; } }

        }
    }
}