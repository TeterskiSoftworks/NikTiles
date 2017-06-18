namespace NikTiles.Editor.Forms.FloorMenu {
    partial class TextureMenu {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextureMenu));
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.verticalFlipButton = new System.Windows.Forms.Button();
            this.horizontalFlipButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.materialEditPreview = new NikTiles.Editor.Forms.FloorMenu.MaterialEditPreview();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.menuLabel = new System.Windows.Forms.Label();
            this.bottomTextureButton = new System.Windows.Forms.RadioButton();
            this.topTextureButton = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.flipButton = new System.Windows.Forms.Button();
            this.bottomAlphaBox = new System.Windows.Forms.MaskedTextBox();
            this.topAlphaBox = new System.Windows.Forms.MaskedTextBox();
            this.bottomColorButton = new System.Windows.Forms.Button();
            this.topColorButton = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox.Controls.Add(this.verticalFlipButton);
            this.groupBox.Controls.Add(this.horizontalFlipButton);
            this.groupBox.Controls.Add(this.button1);
            this.groupBox.Controls.Add(this.materialEditPreview);
            this.groupBox.Controls.Add(this.saveAsButton);
            this.groupBox.Controls.Add(this.menuLabel);
            this.groupBox.Controls.Add(this.bottomTextureButton);
            this.groupBox.Controls.Add(this.topTextureButton);
            this.groupBox.Controls.Add(this.flowLayoutPanel);
            this.groupBox.Controls.Add(this.flipButton);
            this.groupBox.Controls.Add(this.bottomAlphaBox);
            this.groupBox.Controls.Add(this.topAlphaBox);
            this.groupBox.Controls.Add(this.bottomColorButton);
            this.groupBox.Controls.Add(this.topColorButton);
            this.groupBox.Location = new System.Drawing.Point(3, 3);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(278, 250);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            // 
            // verticalFlipButton
            // 
            this.verticalFlipButton.Enabled = false;
            this.verticalFlipButton.Image = ((System.Drawing.Image)(resources.GetObject("verticalFlipButton.Image")));
            this.verticalFlipButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.verticalFlipButton.Location = new System.Drawing.Point(124, 67);
            this.verticalFlipButton.Name = "verticalFlipButton";
            this.verticalFlipButton.Size = new System.Drawing.Size(23, 23);
            this.verticalFlipButton.TabIndex = 24;
            this.verticalFlipButton.UseVisualStyleBackColor = true;
            // 
            // horizontalFlipButton
            // 
            this.horizontalFlipButton.Enabled = false;
            this.horizontalFlipButton.Image = ((System.Drawing.Image)(resources.GetObject("horizontalFlipButton.Image")));
            this.horizontalFlipButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.horizontalFlipButton.Location = new System.Drawing.Point(102, 67);
            this.horizontalFlipButton.Name = "horizontalFlipButton";
            this.horizontalFlipButton.Size = new System.Drawing.Size(23, 23);
            this.horizontalFlipButton.TabIndex = 23;
            this.horizontalFlipButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(177, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Animation Tools";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // materialEditPreview
            // 
            this.materialEditPreview.BackColor = System.Drawing.Color.CornflowerBlue;
            this.materialEditPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.materialEditPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.materialEditPreview.BottomTexture = null;
            this.materialEditPreview.Location = new System.Drawing.Point(8, 19);
            this.materialEditPreview.Name = "materialEditPreview";
            this.materialEditPreview.Size = new System.Drawing.Size(74, 43);
            this.materialEditPreview.TabIndex = 21;
            this.materialEditPreview.TopTexture = null;
            // 
            // saveAsButton
            // 
            this.saveAsButton.Location = new System.Drawing.Point(6, 67);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(75, 23);
            this.saveAsButton.TabIndex = 2;
            this.saveAsButton.Text = "Save As";
            this.saveAsButton.UseVisualStyleBackColor = true;
            // 
            // menuLabel
            // 
            this.menuLabel.AutoSize = true;
            this.menuLabel.BackColor = System.Drawing.SystemColors.Control;
            this.menuLabel.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.bottomTextureButton.Location = new System.Drawing.Point(102, 39);
            this.bottomTextureButton.Name = "bottomTextureButton";
            this.bottomTextureButton.Size = new System.Drawing.Size(118, 22);
            this.bottomTextureButton.TabIndex = 20;
            this.bottomTextureButton.Text = "Bottom_Texture_Name";
            this.bottomTextureButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bottomTextureButton.UseVisualStyleBackColor = true;
            // 
            // topTextureButton
            // 
            this.topTextureButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.topTextureButton.Checked = true;
            this.topTextureButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.topTextureButton.Location = new System.Drawing.Point(102, 18);
            this.topTextureButton.Name = "topTextureButton";
            this.topTextureButton.Size = new System.Drawing.Size(118, 22);
            this.topTextureButton.TabIndex = 19;
            this.topTextureButton.TabStop = true;
            this.topTextureButton.Text = "Top_Texture_Name";
            this.topTextureButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.topTextureButton.UseVisualStyleBackColor = true;
            this.topTextureButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel.Location = new System.Drawing.Point(8, 96);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(262, 148);
            this.flowLayoutPanel.TabIndex = 15;
            // 
            // flipButton
            // 
            this.flipButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.flipButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flipButton.Location = new System.Drawing.Point(81, 18);
            this.flipButton.Name = "flipButton";
            this.flipButton.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.flipButton.Size = new System.Drawing.Size(22, 43);
            this.flipButton.TabIndex = 14;
            this.flipButton.Text = "⇅";
            this.flipButton.UseVisualStyleBackColor = true;
            this.flipButton.Click += new System.EventHandler(this.flipButton_Click);
            // 
            // bottomAlphaBox
            // 
            this.bottomAlphaBox.Location = new System.Drawing.Point(241, 40);
            this.bottomAlphaBox.Mask = "000";
            this.bottomAlphaBox.Name = "bottomAlphaBox";
            this.bottomAlphaBox.PromptChar = ' ';
            this.bottomAlphaBox.Size = new System.Drawing.Size(29, 20);
            this.bottomAlphaBox.TabIndex = 6;
            this.bottomAlphaBox.Text = "255";
            this.bottomAlphaBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.bottomAlphaBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.bottomAlphaBox.TextChanged += new System.EventHandler(this.bottomAlphaBox_TextChanged);
            // 
            // topAlphaBox
            // 
            this.topAlphaBox.Location = new System.Drawing.Point(241, 19);
            this.topAlphaBox.Mask = "000";
            this.topAlphaBox.Name = "topAlphaBox";
            this.topAlphaBox.PromptChar = ' ';
            this.topAlphaBox.Size = new System.Drawing.Size(29, 20);
            this.topAlphaBox.TabIndex = 5;
            this.topAlphaBox.Text = "255";
            this.topAlphaBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.topAlphaBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.topAlphaBox.TextChanged += new System.EventHandler(this.topAlphaBox_TextChanged);
            // 
            // bottomColorButton
            // 
            this.bottomColorButton.BackColor = System.Drawing.Color.White;
            this.bottomColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bottomColorButton.Location = new System.Drawing.Point(220, 40);
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
            this.topColorButton.Location = new System.Drawing.Point(220, 19);
            this.topColorButton.Name = "topColorButton";
            this.topColorButton.Size = new System.Drawing.Size(20, 20);
            this.topColorButton.TabIndex = 3;
            this.topColorButton.UseVisualStyleBackColor = false;
            this.topColorButton.Click += new System.EventHandler(this.topColorButton_Click);
            // 
            // TextureMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.groupBox);
            this.Name = "TextureMenu";
            this.Size = new System.Drawing.Size(284, 256);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label menuLabel;
        private System.Windows.Forms.RadioButton bottomTextureButton;
        private System.Windows.Forms.RadioButton topTextureButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button flipButton;
        private System.Windows.Forms.MaskedTextBox bottomAlphaBox;
        private System.Windows.Forms.MaskedTextBox topAlphaBox;
        private System.Windows.Forms.Button bottomColorButton;
        private System.Windows.Forms.Button topColorButton;
        private MaterialEditPreview materialEditPreview;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button horizontalFlipButton;
        private System.Windows.Forms.Button verticalFlipButton;
        public System.Windows.Forms.Button saveAsButton;
    }
}
