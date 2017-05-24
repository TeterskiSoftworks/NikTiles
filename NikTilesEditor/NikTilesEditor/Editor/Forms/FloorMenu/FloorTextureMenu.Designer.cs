namespace NikTiles.Editor.Forms.FloorMenu {
    partial class FloorTextureMenu {
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.hoverLabel = new System.Windows.Forms.Label();
            this.menuLabel = new System.Windows.Forms.Label();
            this.bottomTextureButton = new System.Windows.Forms.RadioButton();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.topTextureButton = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.flipButton = new System.Windows.Forms.Button();
            this.bottomRowBox = new System.Windows.Forms.MaskedTextBox();
            this.topRowBox = new System.Windows.Forms.MaskedTextBox();
            this.bottomColBox = new System.Windows.Forms.MaskedTextBox();
            this.topColBox = new System.Windows.Forms.MaskedTextBox();
            this.bottomAlphaBox = new System.Windows.Forms.MaskedTextBox();
            this.topAlphaBox = new System.Windows.Forms.MaskedTextBox();
            this.bottomColorButton = new System.Windows.Forms.Button();
            this.topColorButton = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox.Controls.Add(this.saveAsButton);
            this.groupBox.Controls.Add(this.hoverLabel);
            this.groupBox.Controls.Add(this.menuLabel);
            this.groupBox.Controls.Add(this.bottomTextureButton);
            this.groupBox.Controls.Add(this.previewBox);
            this.groupBox.Controls.Add(this.topTextureButton);
            this.groupBox.Controls.Add(this.flowLayoutPanel);
            this.groupBox.Controls.Add(this.flipButton);
            this.groupBox.Controls.Add(this.bottomRowBox);
            this.groupBox.Controls.Add(this.topRowBox);
            this.groupBox.Controls.Add(this.bottomColBox);
            this.groupBox.Controls.Add(this.topColBox);
            this.groupBox.Controls.Add(this.bottomAlphaBox);
            this.groupBox.Controls.Add(this.topAlphaBox);
            this.groupBox.Controls.Add(this.bottomColorButton);
            this.groupBox.Controls.Add(this.topColorButton);
            this.groupBox.Location = new System.Drawing.Point(3, 3);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(318, 268);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            // 
            // saveAsButton
            // 
            this.saveAsButton.Location = new System.Drawing.Point(257, 18);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(57, 32);
            this.saveAsButton.TabIndex = 2;
            this.saveAsButton.Text = "Save As";
            this.saveAsButton.UseVisualStyleBackColor = true;
            // 
            // hoverLabel
            // 
            this.hoverLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.hoverLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hoverLabel.Location = new System.Drawing.Point(76, 19);
            this.hoverLabel.Name = "hoverLabel";
            this.hoverLabel.Size = new System.Drawing.Size(180, 32);
            this.hoverLabel.TabIndex = 7;
            this.hoverLabel.Text = "Hover Label";
            this.hoverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuLabel
            // 
            this.menuLabel.AutoSize = true;
            this.menuLabel.BackColor = System.Drawing.SystemColors.Control;
            this.menuLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.menuLabel.Location = new System.Drawing.Point(6, 2);
            this.menuLabel.Name = "menuLabel";
            this.menuLabel.Size = new System.Drawing.Size(48, 13);
            this.menuLabel.TabIndex = 0;
            this.menuLabel.Text = "Textures";
            this.menuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.menuLabel.Click += new System.EventHandler(this.menuLabel_Click);
            // 
            // bottomTextureButton
            // 
            this.bottomTextureButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.bottomTextureButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bottomTextureButton.Location = new System.Drawing.Point(30, 78);
            this.bottomTextureButton.Name = "bottomTextureButton";
            this.bottomTextureButton.Size = new System.Drawing.Size(118, 22);
            this.bottomTextureButton.TabIndex = 20;
            this.bottomTextureButton.Text = "Bottom_Texture_Name";
            this.bottomTextureButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bottomTextureButton.UseVisualStyleBackColor = true;
            // 
            // previewBox
            // 
            this.previewBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.previewBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.previewBox.Location = new System.Drawing.Point(9, 19);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(64, 32);
            this.previewBox.TabIndex = 0;
            this.previewBox.TabStop = false;
            // 
            // topTextureButton
            // 
            this.topTextureButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.topTextureButton.Checked = true;
            this.topTextureButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.topTextureButton.Location = new System.Drawing.Point(30, 57);
            this.topTextureButton.Name = "topTextureButton";
            this.topTextureButton.Size = new System.Drawing.Size(118, 22);
            this.topTextureButton.TabIndex = 19;
            this.topTextureButton.TabStop = true;
            this.topTextureButton.Text = "Top_Texture_Name";
            this.topTextureButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.topTextureButton.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel.Location = new System.Drawing.Point(8, 105);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(306, 157);
            this.flowLayoutPanel.TabIndex = 15;
            // 
            // flipButton
            // 
            this.flipButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.flipButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flipButton.Location = new System.Drawing.Point(9, 57);
            this.flipButton.Name = "flipButton";
            this.flipButton.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.flipButton.Size = new System.Drawing.Size(22, 43);
            this.flipButton.TabIndex = 14;
            this.flipButton.Text = "⇅";
            this.flipButton.UseVisualStyleBackColor = true;
            this.flipButton.Click += new System.EventHandler(this.flipButton_Click);
            // 
            // bottomRowBox
            // 
            this.bottomRowBox.Enabled = false;
            this.bottomRowBox.Location = new System.Drawing.Point(257, 79);
            this.bottomRowBox.Mask = "0000 rows";
            this.bottomRowBox.Name = "bottomRowBox";
            this.bottomRowBox.PromptChar = ' ';
            this.bottomRowBox.Size = new System.Drawing.Size(57, 20);
            this.bottomRowBox.TabIndex = 10;
            this.bottomRowBox.Text = "   1";
            this.bottomRowBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // topRowBox
            // 
            this.topRowBox.Enabled = false;
            this.topRowBox.Location = new System.Drawing.Point(257, 58);
            this.topRowBox.Mask = "0000 rows";
            this.topRowBox.Name = "topRowBox";
            this.topRowBox.PromptChar = ' ';
            this.topRowBox.Size = new System.Drawing.Size(57, 20);
            this.topRowBox.TabIndex = 9;
            this.topRowBox.Text = "   1";
            this.topRowBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bottomColBox
            // 
            this.bottomColBox.Enabled = false;
            this.bottomColBox.Location = new System.Drawing.Point(199, 79);
            this.bottomColBox.Mask = "0000 cols";
            this.bottomColBox.Name = "bottomColBox";
            this.bottomColBox.PromptChar = ' ';
            this.bottomColBox.Size = new System.Drawing.Size(57, 20);
            this.bottomColBox.TabIndex = 8;
            this.bottomColBox.Text = "   1";
            this.bottomColBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // topColBox
            // 
            this.topColBox.Enabled = false;
            this.topColBox.Location = new System.Drawing.Point(199, 58);
            this.topColBox.Mask = "0000 cols";
            this.topColBox.Name = "topColBox";
            this.topColBox.PromptChar = ' ';
            this.topColBox.Size = new System.Drawing.Size(57, 20);
            this.topColBox.TabIndex = 7;
            this.topColBox.Text = "   1";
            this.topColBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bottomAlphaBox
            // 
            this.bottomAlphaBox.Location = new System.Drawing.Point(169, 79);
            this.bottomAlphaBox.Mask = "00%";
            this.bottomAlphaBox.Name = "bottomAlphaBox";
            this.bottomAlphaBox.PromptChar = ' ';
            this.bottomAlphaBox.Size = new System.Drawing.Size(29, 20);
            this.bottomAlphaBox.TabIndex = 6;
            this.bottomAlphaBox.Text = "99";
            this.bottomAlphaBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // topAlphaBox
            // 
            this.topAlphaBox.Location = new System.Drawing.Point(169, 58);
            this.topAlphaBox.Mask = "00%";
            this.topAlphaBox.Name = "topAlphaBox";
            this.topAlphaBox.PromptChar = ' ';
            this.topAlphaBox.Size = new System.Drawing.Size(29, 20);
            this.topAlphaBox.TabIndex = 5;
            this.topAlphaBox.Text = "99";
            this.topAlphaBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.topAlphaBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // bottomColorButton
            // 
            this.bottomColorButton.BackColor = System.Drawing.Color.White;
            this.bottomColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bottomColorButton.Location = new System.Drawing.Point(148, 79);
            this.bottomColorButton.Name = "bottomColorButton";
            this.bottomColorButton.Size = new System.Drawing.Size(20, 20);
            this.bottomColorButton.TabIndex = 4;
            this.bottomColorButton.UseVisualStyleBackColor = false;
            this.bottomColorButton.Click += new System.EventHandler(this.bottomColorButton_Click);
            // 
            // topColorButton
            // 
            this.topColorButton.BackColor = System.Drawing.Color.White;
            this.topColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.topColorButton.Location = new System.Drawing.Point(148, 58);
            this.topColorButton.Name = "topColorButton";
            this.topColorButton.Size = new System.Drawing.Size(20, 20);
            this.topColorButton.TabIndex = 3;
            this.topColorButton.UseVisualStyleBackColor = false;
            this.topColorButton.Click += new System.EventHandler(this.topColorButton_Click);
            // 
            // FloorTextureMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.groupBox);
            this.Name = "FloorTextureMenu";
            this.Size = new System.Drawing.Size(324, 274);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button saveAsButton;
        private System.Windows.Forms.Label hoverLabel;
        private System.Windows.Forms.Label menuLabel;
        private System.Windows.Forms.RadioButton bottomTextureButton;
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.RadioButton topTextureButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button flipButton;
        private System.Windows.Forms.MaskedTextBox bottomRowBox;
        private System.Windows.Forms.MaskedTextBox topRowBox;
        private System.Windows.Forms.MaskedTextBox bottomColBox;
        private System.Windows.Forms.MaskedTextBox topColBox;
        private System.Windows.Forms.MaskedTextBox bottomAlphaBox;
        private System.Windows.Forms.MaskedTextBox topAlphaBox;
        private System.Windows.Forms.Button bottomColorButton;
        private System.Windows.Forms.Button topColorButton;
    }
}
