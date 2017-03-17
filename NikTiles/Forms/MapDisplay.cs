using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
using NikTiles.Engine;


namespace NikTiles.Forms {

    public class MapDisplay : WinFormsGraphicsDevice.GraphicsDeviceControl {

        #region Static
        private static List<Map> maps = new List<Map>(0);
        private static int currentMap = 0;
        public static Map GetCurrentMap() { return maps[currentMap]; }
        #endregion

        #region Declarations
        private SpriteBatch spriteBatch;
        #endregion

        protected override void Initialize(){
            Application.Idle += delegate { Invalidate(); };
            spriteBatch = new SpriteBatch(GraphicsDevice);
            maps.Add(new Map(10, 10));
            ContentLoader.LoadTextures(GraphicsDevice);
        }

        protected override void Draw(){
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (ContentLoader.textures != null) {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, null, null, null, Camera.transform);
                GetCurrentMap().Draw(spriteBatch);
                spriteBatch.End();
            }
        }
        

    }
}
