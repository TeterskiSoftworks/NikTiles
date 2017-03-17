﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
using NikTiles.Engine;


namespace NikTiles.Forms {

    public class MapDisplay : WinFormsGraphicsDevice.GraphicsDeviceControl {

        #region Static
        private static List<Map> maps = new List<Map>(0);
        private static int currentMap;
        public static Map GetCurrentMap() { return maps[currentMap]; }
        public static void SetCurrentMap(int map) { currentMap = map; }

        /// <summary>
        /// Changes teh current map and updates the size of the MapDisplay viewing the map.
        /// </summary>
        /// <param name="map">Map index</param>
        /// <param name="mapDisplay">The control to be resized.</param>
        public static void SetCurrentMap(int map, MapDisplay mapDisplay) {
            currentMap = map;
            mapDisplay.Width = GetCurrentMap().GetX() * Tile.Width()/2 + Tile.Width()/2;
            mapDisplay.Height = GetCurrentMap().GetY() * Tile.Height()  + Tile.Height()/2;
        }

        #endregion

        #region Declarations
        private SpriteBatch spriteBatch;
        #endregion

        protected override void Initialize(){
            Application.Idle += delegate { Invalidate(); };
            ContentLoader.LoadTextures(GraphicsDevice);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            maps.Add(new Map(100, 100));
            SetCurrentMap(0,this);
        }

        protected override void Draw(){
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (ContentLoader.textures != null) {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp,null, null, null, Camera.transform);
                GetCurrentMap().Draw(spriteBatch);
                spriteBatch.End();
            }
        }
        

    }
}
