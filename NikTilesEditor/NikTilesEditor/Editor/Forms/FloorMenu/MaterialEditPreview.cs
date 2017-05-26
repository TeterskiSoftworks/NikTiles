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
        private Byte topAlpha, bottomAlpha;

        public MaterialEditPreview() {
            InitializeComponent();
            topBitmap    = new Bitmap(Tile.Width, Tile.Height);
            bottomBitmap = new Bitmap(Tile.Width, Tile.Height);
        }

        public void SetTopTexture(Texture top, Color color, byte alpha) {
            this.top = top;
            topBitmap = this.top.ApplyColor(color, alpha);
            BackgroundImage = Texture.BlendImages(bottomBitmap, topBitmap);
        }

        public void SetBottomTexture(Texture bottom, Color color, byte alpha) {
            this.bottom = bottom;
            bottomBitmap = this.bottom.ApplyColor(color, alpha);
            BackgroundImage = Texture.BlendImages(bottomBitmap, topBitmap);
        }

        public void SetTopColor(Color color, byte alpha) {
            topAlpha = alpha;
            topBitmap = top.ApplyColor(color, alpha);
            BackgroundImage = Texture.BlendImages(bottomBitmap, topBitmap);
        }

        public void SetBottomColor(Color color, byte alpha) {
            bottomAlpha = alpha;
            bottomBitmap = bottom.ApplyColor(color, alpha);
            BackgroundImage = Texture.BlendImages(bottomBitmap, topBitmap);
        }

        public void FlipTexture() {
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
