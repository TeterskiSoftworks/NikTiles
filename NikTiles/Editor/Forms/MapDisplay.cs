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
            tile = new Tile(GraphicsDevice);

            camera = new Camera(GraphicsDevice);
            basicEffect = new BasicEffect(GraphicsDevice);
            basicEffect.Alpha = 1.0f;
            basicEffect.VertexColorEnabled = true;
            basicEffect.LightingEnabled = false;
        }

        protected override void Draw() {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (ContentLoader.textures.Count != 0 && false) {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
                spriteBatch.Draw(ContentLoader.textures["test"], rectangle, Color.White);
                spriteBatch.End();
            }
            basicEffect.Projection = camera.GetProjection();
            basicEffect.View = camera.GetView();// can put these last two in initialise instead
            basicEffect.World = camera.GetWorld();//

            tile.Draw();

            //Turn off back face culling
            RasterizerState rasterizerState = new RasterizerState();
            rasterizerState.CullMode = CullMode.None;

            GraphicsDevice.RasterizerState = rasterizerState;

            foreach(EffectPass pass in basicEffect.CurrentTechnique.Passes) {
                pass.Apply();
                //change to strip from list
                GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 3);
            }

        }

    }
}
