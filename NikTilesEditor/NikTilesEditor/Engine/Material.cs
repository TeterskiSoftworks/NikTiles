using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NikTiles.Engine {

    public class Material {

        public static Dictionary<string, Material> floor;


    }

    public class FloorMaterial : Material {
        private string name = "";
        private Texture bottom, top;

        public FloorMaterial(string name, Texture top, Texture bottom) {
            this.name = name;
            this.top = top;
            this.bottom = bottom;
        }

    }

}
