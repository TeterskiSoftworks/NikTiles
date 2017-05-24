namespace NikTiles.Editor.Forms.FloorMenu {
    partial class FloorMaterialMenu {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FloorMaterialMenu));
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.hoverLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.layoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.menuLabel = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.hoverLabel);
            this.groupBox.Controls.Add(this.deleteButton);
            this.groupBox.Controls.Add(this.exportButton);
            this.groupBox.Controls.Add(this.editButton);
            this.groupBox.Controls.Add(this.importButton);
            this.groupBox.Controls.Add(this.applyButton);
            this.groupBox.Controls.Add(this.nameLabel);
            this.groupBox.Controls.Add(this.previewBox);
            this.groupBox.Controls.Add(this.layoutPanel);
            this.groupBox.Controls.Add(this.menuLabel);
            this.groupBox.Location = new System.Drawing.Point(3, 3);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(318, 270);
            this.groupBox.TabIndex = 6;
            this.groupBox.TabStop = false;
            // 
            // hoverLabel
            // 
            this.hoverLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.hoverLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hoverLabel.Location = new System.Drawing.Point(6, 79);
            this.hoverLabel.Name = "hoverLabel";
            this.hoverLabel.Size = new System.Drawing.Size(308, 24);
            this.hoverLabel.TabIndex = 24;
            this.hoverLabel.Text = "Hover Label";
            this.hoverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deleteButton
            // 
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.Location = new System.Drawing.Point(291, 53);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(23, 23);
            this.deleteButton.TabIndex = 23;
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // exportButton
            // 
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(145, 53);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(64, 23);
            this.exportButton.TabIndex = 22;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(75, 53);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(64, 23);
            this.editButton.TabIndex = 21;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // importButton
            // 
            this.importButton.Enabled = false;
            this.importButton.Location = new System.Drawing.Point(215, 53);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(64, 23);
            this.importButton.TabIndex = 20;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(5, 53);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(64, 23);
            this.applyButton.TabIndex = 18;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            // 
            // nameLabel
            // 
            this.nameLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.nameLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.nameLabel.Location = new System.Drawing.Point(76, 18);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(238, 32);
            this.nameLabel.TabIndex = 19;
            this.nameLabel.Text = "Name Label";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previewBox
            // 
            this.previewBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.previewBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.previewBox.Location = new System.Drawing.Point(6, 18);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(64, 32);
            this.previewBox.TabIndex = 17;
            this.previewBox.TabStop = false;
            // 
            // layoutPanel
            // 
            this.layoutPanel.AutoScroll = true;
            this.layoutPanel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.layoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.layoutPanel.Location = new System.Drawing.Point(6, 106);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.Size = new System.Drawing.Size(308, 158);
            this.layoutPanel.TabIndex = 16;
            // 
            // menuLabel
            // 
            this.menuLabel.AutoSize = true;
            this.menuLabel.BackColor = System.Drawing.SystemColors.Control;
            this.menuLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.menuLabel.Location = new System.Drawing.Point(6, 0);
            this.menuLabel.Name = "menuLabel";
            this.menuLabel.Size = new System.Drawing.Size(49, 13);
            this.menuLabel.TabIndex = 1;
            this.menuLabel.Text = "Materials";
            this.menuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.menuLabel.Click += new System.EventHandler(this.menuLabel_Click);
            // 
            // FloorMaterialMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.groupBox);
            this.Name = "FloorMaterialMenu";
            this.Size = new System.Drawing.Size(324, 276);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label hoverLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.FlowLayoutPanel layoutPanel;
        private System.Windows.Forms.Label menuLabel;
    }
}
