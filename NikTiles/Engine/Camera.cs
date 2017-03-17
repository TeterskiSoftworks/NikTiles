using Microsoft.Xna.Framework;
using NikTiles.Forms;
using System;
using System.Collections.Generic;
namespace NikTiles.Engine {

    public static class Camera {

        #region Declarations
        public static Vector2 centre = new Vector2(0, 0);
        public static Vector2 zoom = new Vector2(1, 1);
        public static Matrix transform = Matrix.CreateScale(new Vector3(zoom.X, zoom.Y, 0)) * Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0));
        
        #endregion

        public static void SetCenter(int y, int x) {centre.X = x; centre.Y = y;}

        public static int GetX() {return (int)(centre.X / (Tile.GetX() * zoom.X));}

        public static int GetY() {return (int)(centre.Y / (Tile.GetY() * zoom.Y));}

        public static int GetPixelsX() {return (int)centre.X;}

        public static int GetPixelsY() {return (int)centre.Y;}

        /// <summary>
        /// Transaltes or moves the camera.
        /// </summary>
        /// <param name="y">Change in Y.</param>
        /// <param name="x">Change in X.</param>
        public static void Translate(int y, int x) {
            centre.X += x * Tile.GetX() * zoom.X;
            centre.Y += y * Tile.GetY() * zoom.Y;
        }

        /// <summary>
        /// Sets the zoom factor to a specified value.
        /// Can be used for streatching the scene.
        /// </summary>
        /// <param name="x">X zoom amount.</param>
        /// <param name="y">Z zoom amount.</param>
        public static void Zoom(float y, float x) {
            zoom.X += x; zoom.Y += y;
        }

        /// <summary>
        /// Increases/decreases the zoom facotr by th given ammount.
        /// </summary>
        public static void Zoom(float amount) {
            zoom.X += amount; zoom.Y += amount;
            if (zoom.X < 0.1) zoom.X = 0.1f;
            else if (zoom.X > 2.5) zoom.X = 2.5f;
            if (zoom.Y < 0.1) zoom.Y = 0.1f;
            else if (zoom.Y > 2.5) zoom.Y = 2.5f;
        }

        /// <summary>
        /// Updates the transform matrix.
        /// </summary>
        public static void Update() {
            transform = Matrix.CreateScale(new Vector3(zoom.X, zoom.Y, 0)) * Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0));
        }

        /// <summary>
        /// Makes sure the camera does not go too much out of the map bounds,
        /// allowing for the map to always take up at least 40% of the screen.
        /// </summary>
        /// <param name="mapDisplay">The MapDisplay that uses the camera.</param>
        public static void Boundaries(MapDisplay mapDisplay) {
            if (centre.X < -0.4 * mapDisplay.Width)
                centre.X = (int)(-0.4 * mapDisplay.Width);
            else if (centre.X > (MapDisplay.GetCurrentMap().GetX() * Tile.GetX() / 2 * zoom.X) - 0.4 * mapDisplay.Height)
                centre.X = (int)(MapDisplay.GetCurrentMap().GetX() * Tile.GetX() / 2 * zoom.X - 0.4 * mapDisplay.Height);
            if (centre.Y < -0.4 * mapDisplay.Height)
                centre.Y = (int)(-0.4 * mapDisplay.Height);
            else if (centre.Y > (MapDisplay.GetCurrentMap().GetY() * Tile.GetY() * zoom.Y) - 0.4 * mapDisplay.Height)
                centre.Y = (int)(MapDisplay.GetCurrentMap().GetY() * Tile.GetY() * zoom.Y - 0.4 * mapDisplay.Height);
        }
    }
}
