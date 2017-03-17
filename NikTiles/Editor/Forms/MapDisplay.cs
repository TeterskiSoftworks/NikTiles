using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using NikTiles.Engine;

namespace NikTiles.Editor.Forms{

    public class MapDisplay : WinFormsGraphicsDevice.GraphicsDeviceControl {

        #region Declarations
        private SpriteBatch spriteBatch;
        private Rectangle rectangle;
        private BasicEffect basicEffect;
        private Camera camera;

        Tile tile;
        public static List<Map> maps = new List<Map>(0);
        #endregion

        protected override void Initialize(){
            Application.Idle += delegate { Invalidate(); };

            spriteBatch = new SpriteBatch(GraphicsDevice);
            rectangle = new Rectangle(0, 0, 604, 602);
            ContentLoader.LoadTextures(GraphicsDevice);

            maps.Add(new Map(10, 10));
            tile = new Tile(GraphicsDevice,0,0);

            camera = new Camera(GraphicsDevice);

            basicEffect = new BasicEffect(GraphicsDevice);
            basicEffect.Alpha = 1f;
            basicEffect.TextureEnabled = true;
            basicEffect.VertexColorEnabled = false;
            basicEffect.LightingEnabled = false;
            basicEffect.View = camera.GetView();
            basicEffect.World = camera.GetWorld();

            GraphicsDevice.BlendState = BlendState.NonPremultiplied;
        }

        protected override void Draw() {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (ContentLoader.textures.Count != 0) {

                basicEffect.Projection = camera.GetProjection();

                tile.Draw(basicEffect);
                foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes) {
                    pass.Apply();
                    GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 4);
                }
            }

        }

    }
}
