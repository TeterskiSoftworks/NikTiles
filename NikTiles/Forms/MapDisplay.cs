using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace NikTiles.Forms{

    public class MapDisplay : WinFormsGraphicsDevice.GraphicsDeviceControl {

        private SpriteBatch spriteBatch;
        public Rectangle rectangle;
        Texture2D texture;

        protected override void Initialize(){
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = new Texture2D(GraphicsDevice, 100, 100);
            rectangle = new Rectangle(0, 0, 100, 100);
            Application.Idle += delegate { Invalidate(); };
            Color[] pixels = new Color[texture.Width * texture.Height];
            for(int p=0; p<pixels.Length;p++){
                pixels[p] = Color.White;
            }
            texture.SetData(pixels);
            
        }

        protected override void Draw(){
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, rectangle, Color.White);
            spriteBatch.End();

        }

    }
}
