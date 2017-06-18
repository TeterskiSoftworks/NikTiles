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

        private Texture bottom , top;
        private Bitmap bottomBitmap, topBitmap;

        public MaterialEditPreview() {
            InitializeComponent();
            topBitmap    = new Bitmap(Tile.Width, Tile.Height);
            bottomBitmap = new Bitmap(Tile.Width, Tile.Height);
        }

        public void Initialize() {
            bottom       = Texture.floor["Empty"].Copy();
            top          = Texture.floor["Empty"].Copy();
            topBitmap    = top.GetBitmap();
            bottomBitmap = bottom.GetBitmap();
        }
        
        private new void Update() {
            topBitmap = top.GetBitmap();
            bottomBitmap = bottom.GetBitmap();
            BackgroundImage = Texture.BlendImages(bottomBitmap, topBitmap);
        }

        public Texture TopTexture {
            set {
                if (value != null) {
                    top.DiffuseMap = value.DiffuseMap;
                    Update();
                }
            } get { return top; }
        }

        public Texture BottomTexture {
            set {
                if (value != null) {
                    bottom = value;
                    Update();
                }
            } get { return bottom; }
        }

        public Color TopColor {
            set {
                top.Color = value;
                Update();
            } get { return top.Color; }
        }

        public Color BottomColor {
            set {
                bottom.Color = value;
                Update();
            } get { return bottom.Color; }
        }

        public byte TopAlpha {
            set{
                top.Alpha = value;
                Update();
            } get { return top.Alpha; }
        }

        public byte BottomAlpha {
            set{
                bottom.Alpha = value;
                Update();
            } get { return bottom.Alpha; }
        }

        public void FlipTextures() {

            Texture temp = bottom.Copy();
            bottom = top.Copy();
            top = temp.Copy();

            Update();
        }

        public FloorMaterial CreateMaterial(string name) {
            FloorMaterial material = new FloorMaterial(name, top, bottom);
            return material;
        }


    }
}
