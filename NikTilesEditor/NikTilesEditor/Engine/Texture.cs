using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NikTiles.Engine {
    public class Texture{

        public static Texture2D cursor, selection, grid;

        public static Dictionary<string, Texture2D> floor;

        public Texture() {

        }


        public void FlipVertically() { }
        public void FlipHorizontally() { }

    }


    public class TexturePreview {

        public Texture texture;
        public PictureBox pictureBox;



    }


}
