using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NikTiles.Engine {

    public class Material {

        private readonly string name;
 

        public static Dictionary<string, FloorMaterial> floor = new Dictionary<string, FloorMaterial>();

        public string Name {
            get { return name; }
        }


        public Bitmap GetBitmap() {
            return new Bitmap("");
        }

    }

    public class FloorMaterial : Material {

        private readonly string name;
        private Texture bottom, top;
        private Microsoft.Xna.Framework.Graphics.Texture2D 
            diffuseMap = Texture.floor["Empty"].DiffuseMap;

        public FloorMaterial(string name, Texture top, Texture bottom) {
            this.name = name;
            this.top = top.Copy();
            this.bottom = bottom.Copy();
            diffuseMap = Editor.ContentLoader.CreateTexture2D(
                Texture.BlendImages(bottom.GetBitmap(),top.GetBitmap()));
        }

        public new Bitmap GetBitmap() {
            Bitmap topBitmap = top.GetBitmap();
            Bitmap bottomBitmap = bottom.GetBitmap();

            return Texture.BlendImages(bottomBitmap, topBitmap);
        }

        public Microsoft.Xna.Framework.Graphics.Texture2D DiffuseMap{
            get { return diffuseMap; }
        }

        public new string Name {
            get { return name; }
        }




    }

}
