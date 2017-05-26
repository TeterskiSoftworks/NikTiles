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
    public partial class TextureMenu : UserControl {

        private bool topTextureChecked = true,
                    expanded = true;
        private int groupBoxHeight;

        public TextureMenu() {
            InitializeComponent();
            groupBoxHeight = groupBox.Height;
        }

        public void LoadPreviews() {
            materialEditPreview.Initialize();
            topTextureButton.Text = "Empty";
            bottomTextureButton.Text = "Empty";
            foreach (String texture in Texture.floor.Keys) {
                TexturePreview preview = new TexturePreview();
                preview.Texture = Texture.floor[texture];
                flowLayoutPanel.Controls.Add(preview);
                preview.MouseEnter += new EventHandler(TexturePreview_MouseEnter);
                preview.MouseLeave += new EventHandler(TexturePreview_MouseLeave);
                preview.Click += new EventHandler(TexturePreview_Click);
            }

        }

        private void menuLabel_Click(object sender, EventArgs e) {
            expanded = !expanded;
            if (expanded) {
                flowLayoutPanel.Visible = true;
                groupBox.Size = new Size(groupBox.Width, groupBoxHeight);
            } else {
                groupBox.Size = new Size(groupBox.Width, 18);
                flowLayoutPanel.Visible = false;
            }
        }

        private void flipButton_Click(object sender, EventArgs e) {
            Color tempColor = topColorButton.BackColor;

            topColorButton.BackColor = bottomColorButton.BackColor;
            bottomColorButton.BackColor = tempColor;

            string tempAlhpa = topAlphaBox.Text;
            topAlphaBox.Text = bottomAlphaBox.Text;
            bottomAlphaBox.Text = tempAlhpa;

            string tempTexture = topTextureButton.Text;
            topTextureButton.Text = bottomTextureButton.Text;
            bottomTextureButton.Text = tempTexture;
            
            materialEditPreview.FlipTextures();
            materialEditPreview.TopAlpha = TopAlpha;
            materialEditPreview.BottomAlpha = BottomAlpha;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e) {
            topTextureChecked = topTextureButton.Checked;
        }


        private void topColorButton_Click(object sender, EventArgs e) {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = topColorButton.BackColor;
            colorDialog.FullOpen = true;
            //colorDialog.CustomColors;
            if (colorDialog.ShowDialog() == DialogResult.OK) {
                topColorButton.BackColor = colorDialog.Color;
                materialEditPreview.TopColor = colorDialog.Color;
            }
            colorDialog.Dispose();
        }

        private void bottomColorButton_Click(object sender, EventArgs e) {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = bottomColorButton.BackColor;
            colorDialog.FullOpen = true;
            //colorDialog.CustomColors;
            if (colorDialog.ShowDialog() == DialogResult.OK) {
                bottomColorButton.BackColor = colorDialog.Color;
                materialEditPreview.BottomColor = colorDialog.Color;
            }
            colorDialog.Dispose();
        }


        private void topAlphaBox_TextChanged(object sender, EventArgs e) {
            if (topAlphaBox.Text == "") topAlphaBox.Text = "0";
            materialEditPreview.TopAlpha = TopAlpha;
        }

        private void bottomAlphaBox_TextChanged(object sender, EventArgs e) {
            if (bottomAlphaBox.Text == "") bottomAlphaBox.Text = "0";
            materialEditPreview.BottomAlpha = BottomAlpha;
        }


        private byte TopAlpha {
            get {
                if (topAlphaBox.Text == "99") return byte.MaxValue;
                return (byte)(float.Parse(topAlphaBox.Text) / 100f * 255f);
            }
        }

        private byte BottomAlpha {
            get {
                if (bottomAlphaBox.Text == "99") return byte.MaxValue;
                return (byte)(float.Parse(bottomAlphaBox.Text) / 100f * 255f); }
        }


        public FloorMaterial NewMaterial() {
            NameDialog nameDialog = new NameDialog();
            string name ="";
            if (nameDialog.ShowDialog() == DialogResult.OK) {
                name = nameDialog.textBox.Text;
                nameDialog.Dispose();
                return materialEditPreview.CreateMaterial(name);
            } else {
                return materialEditPreview.CreateMaterial(name);
            }
        }


        #region Texture Preview

        protected void TexturePreview_MouseEnter(object sender, EventArgs e) {
            TexturePreview preview = sender as TexturePreview;
            preview.BackColor = Color.RoyalBlue;
            preview.HideName();
        }

        protected void TexturePreview_MouseLeave(object sender, EventArgs e) {
            TexturePreview preview = sender as TexturePreview;
            preview.BackColor = Color.CornflowerBlue;
            preview.ShowName();
        }

        protected void TexturePreview_Click(object sender, EventArgs e) {
            TexturePreview preview = sender as TexturePreview;
            MouseEventArgs mouse = e as MouseEventArgs;
            if (mouse.Button == MouseButtons.Left) {
                if (topTextureChecked) {
                    topTextureButton.Text = preview.Name;
                    materialEditPreview.TopTexture = preview.Texture;
                    materialEditPreview.Update();
                } else {
                    bottomTextureButton.Text = preview.Name;
                    materialEditPreview.BottomTexture = preview.Texture;
                    materialEditPreview.Update();
                }
            }
        }

        #endregion
    }

}
