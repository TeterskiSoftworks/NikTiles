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

        private Color
            topColor = Color.White,
            bottomColor = Color.White;


        public TextureMenu() {
            InitializeComponent();
            groupBoxHeight = groupBox.Height;
        }

        public void LoadPreviews() {
            foreach (String texture in Texture.floor.Keys) {

                Texture test = new Texture(texture, Texture.floor[texture]);
                TexturePreview preview = new TexturePreview();
                preview.SetTexture(test);
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
            Color tempColor = topColor;
            topColor = bottomColor;
            bottomColor = tempColor;

            topColorButton.BackColor = topColor;
            bottomColorButton.BackColor = bottomColor;

            string tempAlhpa = topAlphaBox.Text;
            topAlphaBox.Text = bottomAlphaBox.Text;
            bottomAlphaBox.Text = tempAlhpa;

            string tempTopCol = topColBox.Text;
            topColBox.Text = bottomColBox.Text;
            bottomColBox.Text = tempTopCol;

            string tempTopRow = topRowBox.Text;
            topRowBox.Text = bottomRowBox.Text;
            bottomRowBox.Text = tempTopRow;

            string tempTexture = topTextureButton.Text;
            topTextureButton.Text = bottomTextureButton.Text;
            bottomTextureButton.Text = tempTexture;


            materialEditPreview.FlipTexture();
            materialEditPreview.SetTopColor(topColor, GetTopAlpha());
            materialEditPreview.SetBottomColor(bottomColor, GetBottomAlpha());
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
                topColor = colorDialog.Color;
                materialEditPreview.SetTopColor(topColor,GetTopAlpha());
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
                bottomColor = colorDialog.Color;
                materialEditPreview.SetBottomColor(bottomColor, GetBottomAlpha());
            }
            colorDialog.Dispose();
        }


        private void topAlphaBox_TextChanged(object sender, EventArgs e) {
            materialEditPreview.SetTopColor(topColor, GetTopAlpha());
        }

        private void bottomAlphaBox_TextChanged(object sender, EventArgs e) {
            materialEditPreview.SetBottomColor(bottomColor, GetBottomAlpha());
        }


        private byte GetTopAlpha() {
            byte alpha = (byte)(float.Parse(topAlphaBox.Text)/100f *255f);
            return alpha;
        }

        private byte GetBottomAlpha() {
            byte alpha = (byte)(float.Parse(bottomAlphaBox.Text) / 100f * 255f);
            return alpha;
        }

        #region Texture Preview
        protected void TexturePreview_MouseEnter(object sender, EventArgs e) {
            TexturePreview preview = sender as TexturePreview;
            preview.BackColor = Color.RoyalBlue;
            preview.HideName();
            hoverLabel.Text = preview.GetTextureName();
        }

        private void saveAsButton_Click(object sender, EventArgs e) {
            NameDialog nameDialog = new NameDialog();
            if(nameDialog.ShowDialog()==DialogResult.OK)
                nameDialog.Dispose();
        }

        protected void TexturePreview_MouseLeave(object sender, EventArgs e) {
            TexturePreview preview = sender as TexturePreview;
            preview.BackColor = Color.CornflowerBlue;
            preview.ShowName();
            hoverLabel.Text = "";
        }

        protected void TexturePreview_Click(object sender, EventArgs e) {
            TexturePreview preview = sender as TexturePreview;
            MouseEventArgs mouse = e as MouseEventArgs;
            if (mouse.Button == MouseButtons.Left) {
                if (topTextureChecked) {
                    topTextureButton.Text = preview.GetTextureName();
                    materialEditPreview.SetTopTexture(preview.GetTexture(), topColorButton.BackColor, GetTopAlpha());
                } else {
                    bottomTextureButton.Text = preview.GetTextureName();
                    materialEditPreview.SetBottomTexture(preview.GetTexture(), bottomColorButton.BackColor, 255);
                }
            }
        }

        #endregion
    }

}
