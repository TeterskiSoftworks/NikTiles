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

namespace NikTiles.Forms{

    public class MapDisplay : WinFormsGraphicsDevice.GraphicsDeviceControl {

        private SpriteBatch spriteBatch;
        public Rectangle rectangle;

        protected override void Initialize(){
            Application.Idle += delegate { Invalidate(); };

            spriteBatch = new SpriteBatch(GraphicsDevice);
            rectangle = new Rectangle(0, 0, 604, 602);
            ContentLoader.LoadTextures(GraphicsDevice);
        }

        protected override void Draw(){
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (ContentLoader.textures.Count != 0) {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
                spriteBatch.Draw(ContentLoader.textures["test"], rectangle, Color.White);
                spriteBatch.End();
            }
        }

    }
}
