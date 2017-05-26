using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NikTiles.Engine;

namespace NikTiles.Editor.Forms.FloorMenu {
    public partial class MaterialEditPreview : UserControl {

        private Texture bottom, top;
        private Bitmap bottomBitmap, topBitmap;

        public MaterialEditPreview() {
            InitializeComponent();
            topBitmap = new Bitmap(Tile.Width, Tile.Height);
            bottomBitmap = new Bitmap(Tile.Width, Tile.Height);
        }

        public void Update() {
            BackgroundImage = Texture.BlendImages(bottomBitmap, topBitmap);
        }

        public Texture TopTexture {
            set {
                top = value;
                topBitmap = this.top.GetBitmap();
                BackgroundImage = Texture.BlendImages(bottomBitmap, topBitmap);
            }
            get { return top; }
        }

        public Texture BottomTexture {
            set {
                bottom = value;
                bottomBitmap = this.bottom.GetBitmap();
                BackgroundImage = Texture.BlendImages(bottomBitmap, topBitmap);
            }
            get { return bottom; }
        }

        public Color TopColor {
            set {
                top.Color = value;
                topBitmap = top.GetBitmap();
                BackgroundImage = Texture.BlendImages(bottomBitmap, topBitmap);
            }
            get { return top.Color; }
        }

        public Color BottomColor {
            set {
                bottom.Color = value;
                bottomBitmap = bottom.GetBitmap();
                BackgroundImage = Texture.BlendImages(bottomBitmap, topBitmap);
            }
            get { return bottom.Color; }
        }

        public byte TopAlpha {
            set{ top.Alpha = value; } get { return top.Alpha; }
        }

        public byte BottomAlpha {
            set{ bottom.Alpha = value; } get { return bottom.Alpha; }
        }

        public void FlipTextures() {
            Texture temp = bottom;
            bottom = top; top = temp;

            Bitmap tempBitmap = bottomBitmap;
            bottomBitmap = topBitmap; topBitmap = tempBitmap;

            BackgroundImage = Texture.BlendImages(bottomBitmap, topBitmap);

        }

        public FloorMaterial CreateMaterial(string name) {
            FloorMaterial material = new FloorMaterial(name, top, bottom);
            return material;
        }


    }
}
