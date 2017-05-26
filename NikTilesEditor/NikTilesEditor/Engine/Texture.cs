using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NikTiles.Engine {
    public class Texture{

        public static Texture2D cursor, selection, grid;
        
        public static Dictionary<string, Texture> floor;


        private readonly string name;
        private Texture2D diffuseMap;
        private byte alpha = 255;
        private Color color = Color.White;

        public Texture(string name, Texture2D diffuseMap) {
            this.name = name;
            this.diffuseMap = diffuseMap;
        }

        public Bitmap GetBitmap() {
            MemoryStream stream = new MemoryStream();
            diffuseMap.SaveAsPng(stream, Tile.Width, Tile.Height);
            Bitmap bitmap = new Bitmap(stream);
            bitmap = ApplyColor(color,alpha);
            stream.Dispose();
            return bitmap;
        }

        public Texture2D DiffuseMap { get { return diffuseMap; } }

        public Color Color { get { return color; } set { color = value; } }

        public byte Alpha { get { return alpha; } set { alpha = value; } }

        public string Name { get {return name;} }

        private Bitmap ApplyColor(Color color, byte alpha) {
            Color = color;
            MemoryStream stream = new MemoryStream();
            diffuseMap.SaveAsPng(stream, Tile.Width, Tile.Height);
            Bitmap bitmap = new Bitmap(stream);
            Color newColor, oldColor;
            this.alpha = alpha;

            for(int y=0; y<bitmap.Height; y++) {
                for (int x = 0; x < bitmap.Width; x++) {
                    oldColor = bitmap.GetPixel(x, y);
                    
                    newColor = AddColors(oldColor, color);
                    bitmap.SetPixel(x, y, newColor);
                }
            }
            stream.Dispose();
            return bitmap;
        }

        private Color AddColors(Color original, Color add) {
            Color color = Color.FromArgb(
                (int)(original.A * alpha/255f),
                (int)(add.R * original.R / 255f),
                (int)(add.G * original.G / 255f),
                (int)(add.B * original.B / 255f));
            return color;
        }


        public static Bitmap BlendImages(Bitmap bottom, Bitmap top) {
            Bitmap bitmap = new Bitmap(Tile.Width, Tile.Height);
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

        private static Color AlphaBlend(Color src, Color dst) {

            float outA = src.A + dst.A * (1 - src.A / 255f);
            Color color = (outA == 0) ?
                Color.FromArgb(0, 0, 0, 0)
                :
                Color.FromArgb((int)outA,
                (int)((src.R * src.A / 255f + dst.R * dst.A / 255f * (1 - src.A / 255f)) / (outA / 255f)),
                (int)((src.G * src.A / 255f + dst.G * dst.A / 255f * (1 - src.A / 255f)) / (outA / 255f)),
                (int)((src.B * src.A / 255f + dst.B * dst.A / 255f * (1 - src.A / 255f)) / (outA / 255f)));

            return color;
        }


    }

}
