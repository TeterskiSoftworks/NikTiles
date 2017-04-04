using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;
using NikTiles.Editor.Forms;

namespace NikTiles.Engine {
    public static class Cursor {

        #region Fields
        private static Vector2 position = new Vector2(1, 0);
        public static Rectangle rectangle = new Rectangle(0,0,0,0);

        private static Texture2D cursorTexture;
        private static Color[,] mouseMap;
        private static Color mouseMapPosition = new Color();
        private static bool offGrid = false;
        #endregion


        public static void LoadCursorTextures(Color[,] mouseMap, Texture2D cursorTexture) {
            Cursor.mouseMap = mouseMap;
            Cursor.cursorTexture = cursorTexture;
            CreateRectangle();
        }

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
        public static void SetCursor(MouseEventArgs mouse, MapDisplay mapDisplay) {
            position.X = (int)((2 * mouse.X - Tile.Width() * Camera.zoom.X + Camera.centre.X * 2) / (Tile.Width() * Camera.zoom.X));
            if (position.X % 2 != 0) position.X++;
            position.Y = (int)((mouse.Y + Camera.centre.Y) / (Tile.Height() * Camera.zoom.Y));

            OffGridCheck1(mouse, mapDisplay);

            if (!offGrid) {
                mouseMapPosition = mouseMap[
                    (int)(mouse.X / Camera.zoom.X - position.X * Tile.Width() / 2 + Camera.centre.X / Camera.zoom.X) * cursorTexture.Width / Tile.Width(),
                    (int)(mouse.Y / Camera.zoom.Y - position.Y * Tile.Height() + Camera.centre.Y / Camera.zoom.Y) * cursorTexture.Height / Tile.Height()];
                if (mouseMapPosition == Color.Red) {
                    position.X--;
                    position.Y--;
                } else if (mouseMapPosition == Color.Yellow) {
                    position.X--;
                } else if (mouseMapPosition == Color.Green) {
                    position.X++;
                    position.Y--;
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
            if (position.X % 2 != 0)
                rectangle = new Rectangle((int)(position.X * Tile.Width() / 2), (int)(position.Y * Tile.Height() + Tile.Height() / 2), Tile.Width(), Tile.Height());
            else rectangle = new Rectangle((int)(position.X * Tile.Width() / 2), (int)(position.Y * Tile.Height()), Tile.Width(), Tile.Height());
        }

        public static void Draw(SpriteBatch spriteBatch) {
            if (!offGrid) spriteBatch.Draw(cursorTexture, rectangle, Color.White);
        }

        /// <summary>
        /// The first check to see if the cursor is out of bounds of the map, using moue poistion.
        /// </summary>
        /// <param name="mouse"></param>
        /// <param name="mapDisplay"></param>
        public static void OffGridCheck1(MouseEventArgs mouse, MapDisplay mapDisplay) {
            offGrid = false;
            if ((int)(mouse.X / Camera.zoom.X - position.X * Tile.Width() / 2 + Camera.centre.X / Camera.zoom.X) * cursorTexture.Width / Tile.Width() < 0)
                offGrid = true;
            else if ((int)(mouse.Y / Camera.zoom.Y - position.Y * Tile.Height() + Camera.centre.Y / Camera.zoom.Y) * cursorTexture.Height / Tile.Height() < 0)
                offGrid = true;
            else if (position.X > MapDisplay.GetCurrentMap().Width() - 1) offGrid = true;
            else if (position.Y > MapDisplay.GetCurrentMap().Height() - 1) offGrid = true;
        }

        /// <summary>
        /// The second check to see if the mouse hasen't been moved out of the map bounds.
        /// </summary>
        public static void OffGridCheck2() {
            offGrid = false;
            if (position.X < 0) offGrid = true;
            if (position.Y < 0 && position.X % 2 == 0)
                offGrid = true;
            else if (position.X > MapDisplay.GetCurrentMap().Width() - 1) offGrid = true;
            else if (position.Y > MapDisplay.GetCurrentMap().Height() - 1) offGrid = true;
        }

    }
}