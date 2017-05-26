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
    public partial class MaterialPreview : UserControl {

        private Material material;

        public MaterialPreview() {
            InitializeComponent();
            Width = Tile.Width + 10;
            Height = Tile.Height + 10;
            nameLabel.MaximumSize = Size;
            nameLabel.Text = "";
        }

        public void SetMaterial(FloorMaterial material) {
            this.material = material;
            Width = Tile.Width + 10;
            Height = Tile.Height + 10;
            nameLabel.MaximumSize = Size;
            nameLabel.Text = material.Name;
            BackgroundImage = material.GetBitmap();
        }

    }
}
