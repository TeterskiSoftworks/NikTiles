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
                preview.Material = Material.floor[material];
                flowLayoutPanel.Controls.Add(preview);
                preview.MouseEnter += new EventHandler(MaterialPreview_MouseEnter);
                preview.MouseLeave += new EventHandler(MaterialPreview_MouseLeave);
                preview.Click += new EventHandler(MaterialPreview_Click);
            }
        }

        protected void MaterialPreview_MouseEnter(object sender, EventArgs e) {
            MaterialPreview preview = sender as MaterialPreview;
            preview.BackColor = Color.RoyalBlue;
            preview.HideName();
        }

        protected void MaterialPreview_MouseLeave(object sender, EventArgs e) {
            MaterialPreview preview = sender as MaterialPreview;
            preview.BackColor = Color.CornflowerBlue;
            preview.ShowName();
        }

        protected void MaterialPreview_Click(object sender, EventArgs e) {
            MaterialPreview preview = sender as MaterialPreview;
            materialPreview.Material = preview.Material;
            nameLabel.Text = preview.Material.Name;
        }

        private void applyButton_Click(object sender, EventArgs e) {
            Selector.ApplyFloorMaterial(materialPreview.Material.Name);
        }

        public void SetEditButton(System.EventHandler eventHandler) {
            editButton.Click += eventHandler;
        }

        public FloorMaterial CurrentMaterial {
            get { return materialPreview.Material; }
        }

    }
}
