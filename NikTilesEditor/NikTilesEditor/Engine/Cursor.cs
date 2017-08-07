using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;
using NikTiles.Editor.Forms;

namespace NikTiles.Engine {
    public static class Cursor {

        #region Fields
        private static Vector2
            coordinate    = new Vector2(1, 0),
            pixelPosition = new Vector2();

        private static Texture2D floorSprite, wallRightSprite, wallLeftSprite;

        private static Color[] mouseMap;

        private static Color mouseMapPosition = Color.White;
        private static bool offGrid = false;
        
        #endregion

        public static int X { get { return (int)coordinate.X; } }
        public static int Y { get { return (int)coordinate.Y; } }

        public static Vector2 Coordinate { get { return coordinate; } }

        /// <summary>
        /// Sets the cursor on the map based on user mouse movement.
        /// </summary>
        public static void SetCursor(MouseEventArgs mouse) {

            coordinate.X = (int)((2 * mouse.X - Tile.Width * Camera.ZoomX) / (Tile.Width * Camera.ZoomX));
            if (coordinate.X % 2 != 0) coordinate.X++;
            coordinate.Y = (int)(mouse.Y / (Tile.Height * Camera.ZoomY));

            OffGridCheck1(mouse);

            if (!offGrid) {

                // This can possible be simplified with a current MouseMap variable - figure out refernce variables.
                mouseMapPosition = mouseMap[Tile.Width *
                    (int)(mouse.Y / Camera.ZoomY - Y * Tile.Height) * floorSprite.Height / Tile.Height +
                    (int)(mouse.X / Camera.ZoomX - X * Tile.Width / 2) * floorSprite.Width / Tile.Width];
                
                //Brown      165 042 042
                //Gold       255 215 000
                //Aqua       000 255 255
                //Lawn Green 124 252 000

                if (mouseMapPosition == Color.Red) {
                    coordinate.X--;
                    coordinate.Y--;
                } else if (mouseMapPosition == Color.Yellow) {
                    coordinate.X++;
                    coordinate.Y--;
                } else if (mouseMapPosition == Color.Green) {
                    coordinate.X--;
                } else if (mouseMapPosition == Color.Blue) {
                    coordinate.X++;
                }
                OffGridCheck2();
                UpdatePixelPosition();
            }
        }

        /// <summary>
        /// Translates or moves the camera.
        /// </summary>
        /// <param name="y">Change in Y.</param>
        /// <param name="x">Change in X.</param>
        public static void Translate(int y, int x) {
            coordinate.X += x; coordinate.Y += x;
            UpdatePixelPosition();
        }

        /// <summary>
        /// The first check to see if the cursor is out of bounds of the map, using mouse poistion.
        /// </summary>
        private static void OffGridCheck1(MouseEventArgs mouse) {
            offGrid = false;
            if ((int)(mouse.X / Camera.ZoomX - coordinate.X * Tile.Width / 2 + Camera.GetPixelsX() / Camera.ZoomX) * floorSprite.Width / Tile.Width < 0)
                offGrid = true;
            else if ((int)(mouse.Y / Camera.ZoomY - coordinate.Y * Tile.Height + Camera.GetPixelsY() / Camera.ZoomY) * floorSprite.Height / Tile.Height < 0)
                offGrid = true;
            else if (coordinate.X > MapDisplay.CurrentMap.Width - 1) offGrid = true;
            else if (coordinate.Y > MapDisplay.CurrentMap.Height - 1) offGrid = true;
        }

        /// <summary>
        /// The second check to see if the mouse hasen't been moved out of the map bounds.
        /// It checks too see if the cursor is still inbounds once its location has been
        /// transformed by the mouse map.
        /// </summary>
        private static void OffGridCheck2() {
            offGrid = false;
            if (coordinate.X < 0) offGrid = true;
            if (coordinate.Y < 0 && coordinate.X % 2 != 0)
                offGrid = true;
            else if (coordinate.X > MapDisplay.CurrentMap.Width - 1) offGrid = true;
            else if (coordinate.Y > MapDisplay.CurrentMap.Height - 1) offGrid = true;
        }

        public static void LoadCursorTextures(Color[] mouseMap, Texture2D floorSprite, Texture2D wallSprite) {
            Cursor.mouseMap = mouseMap;
            Cursor.floorSprite = floorSprite;
            wallLeftSprite = wallSprite;
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            wallSprite.SaveAsPng(stream, wallSprite.Width, wallSprite.Height);
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(stream, true);
            bitmap.RotateFlip(System.Drawing.RotateFlipType.RotateNoneFlipX);
            stream.Dispose();
            wallRightSprite = Editor.ContentLoader.CreateTexture2D(bitmap);
            UpdatePixelPosition();
        }

        public static void Draw(SpriteBatch spriteBatch) {
            if (!offGrid) {
                switch (MapEditor.Mode) {

                    #region Floor
                    case MapEditor.Modes.Floor:
                        spriteBatch.Draw(floorSprite, pixelPosition, Color.White);
                        break;
                    #endregion

                    #region Wall
                    case MapEditor.Modes.Wall:
                        spriteBatch.Draw(
                            mouseMapPosition == Color.Gold || mouseMapPosition == Color.Yellow ||
                            mouseMapPosition == Color.LawnGreen || mouseMapPosition == Color.Green ?
                            wallRightSprite : wallLeftSprite, pixelPosition, Color.White);
                        break;
                        #endregion
                }
            }
        }
        
        public static void UpdatePixelPosition() {
            switch (MapEditor.Mode) {
                case MapEditor.Modes.Floor:
                    if (X % 2 != 0) {
                        pixelPosition.X = X * Tile.Width / 2;
                        pixelPosition.Y = Y * Tile.Height + Tile.Height / 2;
                    } else {
                        pixelPosition.X = X * Tile.Width / 2;
                        pixelPosition.Y = Y * Tile.Height;
                    }
                    break;
                case MapEditor.Modes.Wall:
                    pixelPosition.X = mouseMapPosition == Color.Yellow || mouseMapPosition == Color.Blue ||
                                      mouseMapPosition == Color.Brown  || mouseMapPosition == Color.LawnGreen ?
                                      X * Tile.Width / 2 : (X + 1) * Tile.Width / 2;

                    pixelPosition.Y = mouseMapPosition == Color.Green || mouseMapPosition == Color.Blue ||
                                      mouseMapPosition == Color.LawnGreen || mouseMapPosition == Color.Aqua ?
                                      (int)((Y - 0.5) * Tile.Height + 1) :
                                      mouseMapPosition == Color.Red || mouseMapPosition == Color.Yellow ?
                                      Y * Tile.Height + 1 : (Y - 1) * Tile.Height + 1;
                    break;
            }
        }

        public static Color MouseMapPosition {
            get { return mouseMapPosition; }
        }
    }
}