using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NikTiles.Editor.Forms {
    public partial class SelectionToolStrip : UserControl {

        private string oldWidth="1";

        public SelectionToolStrip() {
            InitializeComponent();
        }

        public void ResetMode(ref object button) {
            pointButton.Checked    = button == pointButton;
            lineButton.Checked     = button == lineButton;
            boxAlignButton.Checked = button == boxAlignButton;
            boxButton.Checked      = button == boxButton;
            circleButton.Checked   = button == circleButton;
        }

        public void SetMode(int key) {
            object nullObject = new Object();
            ResetMode(ref nullObject);
            if (key == 1) pointButton.Checked = true;
            else if (key == 2) lineButton.Checked = true;
            else if (key == 3) boxAlignButton.Checked = true;
            else if (key == 4) boxButton.Checked = true;
        }

        private void Button_Click(object sender, EventArgs e) {
            ResetMode(ref sender);
        }

        private void PointButton_CheckedChanged(object sender, EventArgs e) {
            if (pointButton.Checked) {
                Selector.SetMode(Selector.Mode.Point);
                fillButton.Enabled = false;
                fillButton.Checked = false;
                widthBox.Enabled = false;
            }
        }

        private void LineButton_CheckedChanged(object sender, EventArgs e) {
            if (lineButton.Checked) {
                Selector.SetMode(Selector.Mode.Line);
                fillButton.Enabled = false;
                fillButton.Checked = false;
                widthBox.Enabled = false;
            }
        }

        private void BoxAlignButton_CheckedChanged(object sender, EventArgs e) {
            if (boxAlignButton.Checked) {
                Selector.SetMode(Selector.Mode.BoxAlign);
                fillButton.Enabled = true;
                widthBox.Enabled = !fillButton.Checked;
            }
        }

        private void BoxButton_CheckedChanged(object sender, EventArgs e) {
            if (boxButton.Checked) {
                Selector.SetMode(Selector.Mode.Box);
                fillButton.Enabled = true;
                widthBox.Enabled = !fillButton.Checked;
            }

        }

        private void WidthBox_TextChanged(object sender, EventArgs e) {
            if (int.TryParse(widthBox.Text,out int newWidth)) {
                SetWidth();
                oldWidth = newWidth.ToString();
            } else {
                MessageBox.Show("Only numeric characters may be entered.", "Error: Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                widthBox.Text = oldWidth;
            }
        }

        private void SetWidth() {
            int width;
            if (widthBox.Text == "") {
                width = 1;
                widthBox.Text = "1";
            } else {
                widthBox.Text = widthBox.Text.Replace(" ", "");
                width = int.Parse(widthBox.Text);
            }
            Selector.SetWidth(width);
        }


        private void FillButton_CheckedChanged(object sender, EventArgs e) {
            if (fillButton.Checked) {
                Selector.SetWidth(-1);
                widthBox.Enabled = false;
            } else {
                SetWidth();
                widthBox.Enabled = true;
            }
        }

        public void DeslectToggle() {
            deselectButton.Checked = !deselectButton.Checked;
        }

        public void FillToggle() {
            fillButton.Checked = !fillButton.Checked && fillButton.Enabled;
        }

        private void deselectButton_CheckedChanged(object sender, EventArgs e) {
            Selector.Deselect(deselectButton.Checked);
        }
    }
    
}
