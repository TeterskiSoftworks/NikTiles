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
    public partial class FloorTextureMenu : UserControl {

        private bool topTextureChecked = true,
                    expanded = true;
        private int groupBoxHeight;

        private Color
            topColor = Color.White,
            bottomColor = Color.White;


        public FloorTextureMenu() {
            InitializeComponent();
            groupBoxHeight = groupBox.Height;
            //ContentLoader.LoadTextures(GraphicsDevice);
            //LoadPreviews();
        }

        public void LoadPreviews() {
            foreach (String texture in Texture.floor.Keys) {
                flowLayoutPanel.Controls.Add(new PictureBox());
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

        }

        private void topColorButton_Click(object sender, EventArgs e) {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = topColorButton.BackColor;
            colorDialog.FullOpen = true;
            //colorDialog.CustomColors;
            if (colorDialog.ShowDialog() == DialogResult.OK) {
                topColorButton.BackColor = colorDialog.Color;
                topColor = colorDialog.Color;
                //editorPreview.topTexture.color = topColor;
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
                //editorPreview.topTexture.color = bottomColor;
            }
            colorDialog.Dispose();
        }

        private void topTextureRadioButton_CheckedChanged(object sender, EventArgs e) {
            topTextureChecked = topTextureButton.Checked;
        }
    }
}
