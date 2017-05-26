using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NikTiles.Engine {
    public class Texture{

        public static Texture2D cursor, selection, grid;
        
        public static Dictionary<string, Texture> floor;


        private string name = "";
        private Texture2D texture;
        private byte alpha = 255;
        private Microsoft.Xna.Framework.Color color = Microsoft.Xna.Framework.Color.White;

        public Texture(string name, Texture2D texture) {
            this.name = name;
            this.texture = texture;
        }

        public Bitmap GetBitmap() {
            MemoryStream stream = new MemoryStream();
            texture.SaveAsPng(stream, Tile.Width(), Tile.Height());
            Bitmap bitmap = new Bitmap(stream);
            stream.Dispose();
            return bitmap;
        }

        public Texture2D GetTexture() {
            return texture;
        }

        public string Name() {
            return name;
        }

        public void Name(string name) {
            this.name = name;
        }

        public Bitmap ApplyColor(Color color, byte alpha) {
            MemoryStream stream = new MemoryStream();
            texture.SaveAsPng(stream, Tile.Width(), Tile.Height());
            Bitmap bitmap = new Bitmap(stream);
            Color newColor, oldColor;
            this.alpha = alpha;

            for(int y=0; y<bitmap.Height; y++) {
                for (int x = 0; x < bitmap.Width; x++) {
                    oldColor = bitmap.GetPixel(x, y);
                    
                    newColor = AddColor(oldColor, color,alpha);
                    bitmap.SetPixel(x, y, newColor);
                }
            }
            stream.Dispose();
            return bitmap;
        }

        private static Color AddColor(Color original, Color add, byte alpha) {
            Color color = Color.FromArgb(
                (int)(original.A * alpha/255f),
                (int)(add.R * original.R / 255f),
                (int)(add.G * original.G / 255f),
                (int)(add.B * original.B / 255f));
            return color;
        }

        private static Color AlphaBlend(Color src, Color dst) {

            float outA = src.A + dst.A * (1 - src.A/255f);
            Color color = (outA == 0) ?
                Color.FromArgb(0, 0, 0, 0)
                :
                Color.FromArgb( (int)outA,
                (int)((src.R * src.A / 255f + dst.R * dst.A / 255f * (1 - src.A / 255f)) / (outA/255f)),
                (int)((src.G * src.A / 255f + dst.G * dst.A / 255f * (1 - src.A / 255f)) / (outA/255f)),
                (int)((src.B * src.A / 255f + dst.B * dst.A / 255f * (1 - src.A / 255f)) / (outA/255f)));

            return color;
        }

        public static Bitmap BlendImages(Bitmap bottom, Bitmap top) {
            Bitmap bitmap = new Bitmap(Tile.Width(), Tile.Height());
            Color newColor, bottomColor, topColor;

            for (int y = 0; y < bitmap.Height; y++) {
                for (int x = 0; x < bitmap.Width; x++) {
                    bottomColor = bottom.GetPixel(x, y);
                    topColor = top.GetPixel(x, y);
                    newColor = AlphaBlend(topColor, bottomColor);
                    bitmap.SetPixel(x, y, newColor);
                }
            }

            return bitmap;
        }


        public void FlipVertically() { }
        public void FlipHorizontally() { }

    }

}
