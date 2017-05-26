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

        public FloorMaterial(string name, Texture top, Texture bottom) {
            this.name = name;
            this.top = top;
            this.bottom = bottom;
        }

        public new Bitmap GetBitmap() {
            Bitmap topBitmap = top.GetBitmap();
            Bitmap bottomBitmap = bottom.GetBitmap();

            return topBitmap;
        }

        public new string Name {
            get { return name; }
        }

    }

}
