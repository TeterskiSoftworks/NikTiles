namespace NikTiles.Editor.Forms.FloorMenu {
    partial class MaterialMenu {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialMenu));
            this.groupBox = new System.Windows.Forms.GroupBox();
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
            this.groupBox.Size = new System.Drawing.Size(278, 249);
            this.groupBox.TabIndex = 6;
            this.groupBox.TabStop = false;
            // 
            // deleteButton
            // 
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.Location = new System.Drawing.Point(245, 66);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(23, 23);
            this.deleteButton.TabIndex = 23;
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // exportButton
            // 
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(189, 66);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(57, 23);
            this.exportButton.TabIndex = 22;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(69, 66);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(57, 23);
            this.editButton.TabIndex = 21;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // importButton
            // 
            this.importButton.Enabled = false;
            this.importButton.Location = new System.Drawing.Point(133, 66);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(57, 23);
            this.importButton.TabIndex = 20;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(6, 66);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(57, 23);
            this.applyButton.TabIndex = 18;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            // 
            // nameLabel
            // 
            this.nameLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.nameLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.nameLabel.Location = new System.Drawing.Point(86, 18);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(182, 42);
            this.nameLabel.TabIndex = 19;
            this.nameLabel.Text = "Name Label";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previewBox
            // 
            this.previewBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.previewBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.previewBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.previewBox.Location = new System.Drawing.Point(6, 18);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(74, 43);
            this.previewBox.TabIndex = 17;
            this.previewBox.TabStop = false;
            // 
            // layoutPanel
            // 
            this.layoutPanel.AutoScroll = true;
            this.layoutPanel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.layoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.layoutPanel.Location = new System.Drawing.Point(6, 95);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.Size = new System.Drawing.Size(262, 148);
            this.layoutPanel.TabIndex = 16;
            // 
            // menuLabel
            // 
            this.menuLabel.AutoSize = true;
            this.menuLabel.BackColor = System.Drawing.SystemColors.Control;
            this.menuLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.menuLabel.Location = new System.Drawing.Point(6, 0);
            this.menuLabel.Name = "menuLabel";
            this.menuLabel.Size = new System.Drawing.Size(49, 13);
            this.menuLabel.TabIndex = 1;
            this.menuLabel.Text = "Materials";
            this.menuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.menuLabel.Click += new System.EventHandler(this.menuLabel_Click);
            // 
            // MaterialMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.groupBox);
            this.Name = "MaterialMenu";
            this.Size = new System.Drawing.Size(284, 255);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
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
