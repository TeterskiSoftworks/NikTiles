using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
using NikTiles.Engine;


namespace NikTiles.Editor.Forms {

    public class MapDisplay : WinFormsGraphicsDevice.GraphicsDeviceControl {

        #region Static
        private static List<Map> maps = new List<Map>(0);
        private static int currentMap;

        public static Map CurrentMap { get { return maps[currentMap]; } }
        
        public static void SetCurrentMap(int map) { currentMap = map; }

        /// <summary>
        /// Changes teh current map and updates the size of the MapDisplay viewing the map.
        /// </summary>
        /// <param name="map">Map index</param>
        /// <param name="mapDisplay">The control to be resized.</param>
        public static void SetCurrentMap(int map, MapDisplay mapDisplay) {
            currentMap = map;
            mapDisplay.Width = (int)(CurrentMap.Width * Camera.ZoomX * Tile.Width / 2 + Camera.ZoomX * Tile.Width / 2);
            mapDisplay.Height = (int)(CurrentMap.Height * Camera.ZoomY * Tile.Height + Camera.ZoomY * Tile.Height / 2);
        }
        #endregion

        #region Declarations
        private SpriteBatch spriteBatch;
        private int width, height;  //The dimensions of the visible space.
        #endregion

        protected override void Initialize() {

            Application.Idle += delegate { Invalidate(); };
            
            ContentLoader.LoadTextures(GraphicsDevice, Services);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            maps.Add(new Map(100, 100));
            SetCurrentMap(0, this);
        }

        protected override void Draw() {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (Engine.Texture.floor != null) { //add more advanced check later
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, null, null, null, Camera.GetTransform());
                CurrentMap.Draw(spriteBatch, width, height);
                Engine.Cursor.Draw(spriteBatch);
                spriteBatch.End();
            }
        }


        /// <summary>  Updates how much of the MapDisplay is visible. </summary>
        /// <param name="width">View width.</param>
        /// <param name="height">View height.</param>
        public void ResizeView(int width, int height) {
            this.width = width;
            this.height = height;
        }

    }
}