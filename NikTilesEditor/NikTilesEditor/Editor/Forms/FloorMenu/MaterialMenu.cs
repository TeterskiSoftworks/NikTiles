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
                flowLayoutPanel.Visible = true;
                groupBox.Size = new Size(groupBox.Width, groupBoxHeight);
            } else {
                groupBox.Size = new Size(groupBox.Width, 18);
                flowLayoutPanel.Visible = false;
            }
        }

        public void LoadPreviews() {
            flowLayoutPanel.Controls.Clear();
            foreach (String material in Material.floor.Keys) {
                MaterialPreview preview = new MaterialPreview();
                preview.SetMaterial(Material.floor[material]);
                flowLayoutPanel.Controls.Add(preview);
            }
        }

    }
}
