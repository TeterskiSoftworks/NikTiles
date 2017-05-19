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
        public SelectionToolStrip() {
            InitializeComponent();
        }

        public void ResetMode(ref object button) {
            selectionPointButton.Checked    = button == selectionPointButton;
            selectionLineButton.Checked     = button == selectionLineButton;
            selectionBoxAlignButton.Checked = button == selectionBoxAlignButton;
            selectionBoxButton.Checked      = button == selectionBoxButton;
        }

        public void SetMode(int key) {
            object nullObject = new Object();
            ResetMode(ref nullObject);
            if (key == 1) selectionPointButton.Checked = true;
            else if (key == 2) selectionLineButton.Checked = true;
            else if (key == 3) selectionBoxAlignButton.Checked = true;
            else if (key == 4) selectionBoxButton.Checked = true;
        }

        private void selectionButton_Click(object sender, EventArgs e) {
            ResetMode(ref sender);
        }

        private void selectionPointButton_CheckedChanged(object sender, EventArgs e) {
            if(selectionPointButton.Checked)Selector.SetMode(Selector.Mode.Point);
        }

        private void selectionLineButton_CheckedChanged(object sender, EventArgs e) {
            if (selectionLineButton.Checked) Selector.SetMode(Selector.Mode.Line);
        }

        private void selectionBoxAlignButton_CheckedChanged(object sender, EventArgs e) {
            if (selectionBoxAlignButton.Checked) Selector.SetMode(Selector.Mode.BoxAlign);
        }

        private void selectionBoxButton_CheckedChanged(object sender, EventArgs e) {
            if (selectionBoxButton.Checked) Selector.SetMode(Selector.Mode.Box);
        }
    }
    
}
