namespace NikTiles.Editor.Forms {
    partial class SelectionToolStrip {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionToolStrip));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.selectionBoxButton = new System.Windows.Forms.ToolStripButton();
            this.selectionLineButton = new System.Windows.Forms.ToolStripButton();
            this.selectionPointButton = new System.Windows.Forms.ToolStripButton();
            this.selectionWidthLabel = new System.Windows.Forms.ToolStripLabel();
            this.selectionBoxAlignButton = new System.Windows.Forms.ToolStripButton();
            this.selectionWidthBox = new System.Windows.Forms.MaskedTextBox();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectionWidthLabel,
            this.selectionPointButton,
            this.selectionLineButton,
            this.selectionBoxAlignButton,
            this.selectionBoxButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(312, 25);
            this.toolStrip.TabIndex = 2;
            // 
            // selectionBoxButton
            // 
            this.selectionBoxButton.CheckOnClick = true;
            this.selectionBoxButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectionBoxButton.Image = ((System.Drawing.Image)(resources.GetObject("selectionBoxButton.Image")));
            this.selectionBoxButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectionBoxButton.Name = "selectionBoxButton";
            this.selectionBoxButton.Size = new System.Drawing.Size(23, 22);
            this.selectionBoxButton.Text = "toolStripButton3";
            this.selectionBoxButton.ToolTipText = "Box";
            this.selectionBoxButton.CheckedChanged += new System.EventHandler(this.selectionBoxButton_CheckedChanged);
            this.selectionBoxButton.Click += new System.EventHandler(this.selectionButton_Click);
            // 
            // selectionLineButton
            // 
            this.selectionLineButton.CheckOnClick = true;
            this.selectionLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectionLineButton.Image = ((System.Drawing.Image)(resources.GetObject("selectionLineButton.Image")));
            this.selectionLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectionLineButton.Name = "selectionLineButton";
            this.selectionLineButton.Size = new System.Drawing.Size(23, 22);
            this.selectionLineButton.Text = "toolStripButton2";
            this.selectionLineButton.ToolTipText = "Line";
            this.selectionLineButton.CheckedChanged += new System.EventHandler(this.selectionLineButton_CheckedChanged);
            this.selectionLineButton.Click += new System.EventHandler(this.selectionButton_Click);
            // 
            // selectionPointButton
            // 
            this.selectionPointButton.Checked = true;
            this.selectionPointButton.CheckOnClick = true;
            this.selectionPointButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectionPointButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectionPointButton.Image = ((System.Drawing.Image)(resources.GetObject("selectionPointButton.Image")));
            this.selectionPointButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectionPointButton.Name = "selectionPointButton";
            this.selectionPointButton.Size = new System.Drawing.Size(23, 22);
            this.selectionPointButton.Text = "toolStripButton1";
            this.selectionPointButton.ToolTipText = "Point";
            this.selectionPointButton.CheckedChanged += new System.EventHandler(this.selectionPointButton_CheckedChanged);
            this.selectionPointButton.Click += new System.EventHandler(this.selectionButton_Click);
            // 
            // selectionWidthLabel
            // 
            this.selectionWidthLabel.Name = "selectionWidthLabel";
            this.selectionWidthLabel.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.selectionWidthLabel.Size = new System.Drawing.Size(72, 22);
            this.selectionWidthLabel.Text = "Width:";
            this.selectionWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // selectionBoxAlignButton
            // 
            this.selectionBoxAlignButton.CheckOnClick = true;
            this.selectionBoxAlignButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectionBoxAlignButton.Image = ((System.Drawing.Image)(resources.GetObject("selectionBoxAlignButton.Image")));
            this.selectionBoxAlignButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectionBoxAlignButton.Name = "selectionBoxAlignButton";
            this.selectionBoxAlignButton.Size = new System.Drawing.Size(23, 22);
            this.selectionBoxAlignButton.Text = "toolStripButton4";
            this.selectionBoxAlignButton.ToolTipText = "Box - Aligned";
            this.selectionBoxAlignButton.CheckedChanged += new System.EventHandler(this.selectionBoxAlignButton_CheckedChanged);
            this.selectionBoxAlignButton.Click += new System.EventHandler(this.selectionButton_Click);
            // 
            // selectionWidthBox
            // 
            this.selectionWidthBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.selectionWidthBox.Location = new System.Drawing.Point(42, 2);
            this.selectionWidthBox.Mask = "000";
            this.selectionWidthBox.Name = "selectionWidthBox";
            this.selectionWidthBox.PromptChar = ' ';
            this.selectionWidthBox.Size = new System.Drawing.Size(25, 20);
            this.selectionWidthBox.TabIndex = 3;
            this.selectionWidthBox.Text = "1";
            this.selectionWidthBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // SelectionToolStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.selectionWidthBox);
            this.Controls.Add(this.toolStrip);
            this.Name = "SelectionToolStrip";
            this.Size = new System.Drawing.Size(312, 65);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton selectionBoxAlignButton;
        private System.Windows.Forms.ToolStripButton selectionBoxButton;
        private System.Windows.Forms.ToolStripButton selectionLineButton;
        private System.Windows.Forms.ToolStripButton selectionPointButton;
        private System.Windows.Forms.ToolStripLabel selectionWidthLabel;
        private System.Windows.Forms.MaskedTextBox selectionWidthBox;
    }
}
