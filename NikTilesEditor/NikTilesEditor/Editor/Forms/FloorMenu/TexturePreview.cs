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
    public partial class TexturePreview : UserControl {

        private Texture texture;

        public TexturePreview() {
            InitializeComponent();
            Width = Tile.Width+10;
            Height = Tile.Height+10;
            nameLabel.MaximumSize = Size;
            nameLabel.Text = "";
        }

        public void SetTexture(Texture texture) {
            this.texture = texture;
            Width = Tile.Width+10;
            Height = Tile.Height+10;
            nameLabel.MaximumSize = Size;
            nameLabel.Text = texture.Name;
            BackgroundImage = texture.GetBitmap();
        }

        public string GetTextureName() {
            return texture.Name;
        }

        public Texture GetTexture() {
            return texture;
        }

        public void HideName() {
            nameLabel.ForeColor = Color.White;
        }

        public void ShowName() {
            nameLabel.ForeColor = Color.Black;
        }

        private void nameLabel_Click(object sender, EventArgs e) {
            InvokeOnClick(this, e);
        }

        private void nameLabel_MouseEnter(object sender, EventArgs e) {
            OnMouseEnter(e);
        }

        private void nameLabel_MouseLeave(object sender, EventArgs e) {
            OnMouseLeave(e);
        }
    }
}
