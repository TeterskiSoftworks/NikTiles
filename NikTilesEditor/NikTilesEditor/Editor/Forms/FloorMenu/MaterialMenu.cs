using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NikTiles.Editor.Forms.FloorMenu {
    public partial class MaterialMenu : UserControl {

        private bool expanded = true;
        private int groupBoxHeight;

        public MaterialMenu() {
            InitializeComponent();
            groupBoxHeight = groupBox.Height;
        }

        private void menuLabel_Click(object sender, EventArgs e) {
            expanded = !expanded;
            if (expanded) {
                layoutPanel.Visible = true;
                groupBox.Size = new Size(groupBox.Width, groupBoxHeight);
            } else {
                groupBox.Size = new Size(groupBox.Width, 18);
                layoutPanel.Visible = false;
            }
        }
    }
}
