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
            this.widthLabel = new System.Windows.Forms.ToolStripLabel();
            this.fillButton = new System.Windows.Forms.ToolStripButton();
            this.pointButton = new System.Windows.Forms.ToolStripButton();
            this.lineButton = new System.Windows.Forms.ToolStripButton();
            this.boxAlignButton = new System.Windows.Forms.ToolStripButton();
            this.boxButton = new System.Windows.Forms.ToolStripButton();
            this.circleButton = new System.Windows.Forms.ToolStripButton();
            this.deselectButton = new System.Windows.Forms.ToolStripButton();
            this.widthBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.widthLabel,
            this.widthBox,
            this.fillButton,
            this.pointButton,
            this.lineButton,
            this.boxAlignButton,
            this.boxButton,
            this.circleButton,
            this.deselectButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(290, 25);
            this.toolStrip.TabIndex = 2;
            // 
            // widthLabel
            // 
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(42, 22);
            this.widthLabel.Text = "Width:";
            this.widthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fillButton
            // 
            this.fillButton.CheckOnClick = true;
            this.fillButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fillButton.Enabled = false;
            this.fillButton.Image = ((System.Drawing.Image)(resources.GetObject("fillButton.Image")));
            this.fillButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fillButton.Name = "fillButton";
            this.fillButton.Size = new System.Drawing.Size(23, 22);
            this.fillButton.Text = "Fill";
            this.fillButton.ToolTipText = "Fill";
            this.fillButton.CheckedChanged += new System.EventHandler(this.FillButton_CheckedChanged);
            // 
            // pointButton
            // 
            this.pointButton.Checked = true;
            this.pointButton.CheckOnClick = true;
            this.pointButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pointButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pointButton.Image = ((System.Drawing.Image)(resources.GetObject("pointButton.Image")));
            this.pointButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pointButton.Name = "pointButton";
            this.pointButton.Size = new System.Drawing.Size(23, 22);
            this.pointButton.Text = "Pencil";
            this.pointButton.ToolTipText = "Pencil";
            this.pointButton.CheckStateChanged += new System.EventHandler(this.PointButton_CheckedChanged);
            this.pointButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // lineButton
            // 
            this.lineButton.CheckOnClick = true;
            this.lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineButton.Image = ((System.Drawing.Image)(resources.GetObject("lineButton.Image")));
            this.lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(23, 22);
            this.lineButton.Text = "Line";
            this.lineButton.ToolTipText = "Line";
            this.lineButton.CheckStateChanged += new System.EventHandler(this.LineButton_CheckedChanged);
            this.lineButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // boxAlignButton
            // 
            this.boxAlignButton.CheckOnClick = true;
            this.boxAlignButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.boxAlignButton.Image = ((System.Drawing.Image)(resources.GetObject("boxAlignButton.Image")));
            this.boxAlignButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.boxAlignButton.Name = "boxAlignButton";
            this.boxAlignButton.Size = new System.Drawing.Size(23, 22);
            this.boxAlignButton.Text = "Box - Aligned";
            this.boxAlignButton.ToolTipText = "Box - Aligned";
            this.boxAlignButton.CheckStateChanged += new System.EventHandler(this.BoxAlignButton_CheckedChanged);
            this.boxAlignButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // boxButton
            // 
            this.boxButton.CheckOnClick = true;
            this.boxButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.boxButton.Image = ((System.Drawing.Image)(resources.GetObject("boxButton.Image")));
            this.boxButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.boxButton.Name = "boxButton";
            this.boxButton.Size = new System.Drawing.Size(23, 22);
            this.boxButton.Text = "Box";
            this.boxButton.ToolTipText = "Box";
            this.boxButton.CheckStateChanged += new System.EventHandler(this.BoxButton_CheckedChanged);
            this.boxButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // circleButton
            // 
            this.circleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.circleButton.Enabled = false;
            this.circleButton.Image = ((System.Drawing.Image)(resources.GetObject("circleButton.Image")));
            this.circleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(23, 22);
            this.circleButton.Text = "Circle";
            this.circleButton.ToolTipText = "Circle";
            this.circleButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // deselectButton
            // 
            this.deselectButton.CheckOnClick = true;
            this.deselectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deselectButton.Image = ((System.Drawing.Image)(resources.GetObject("deselectButton.Image")));
            this.deselectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deselectButton.Name = "deselectButton";
            this.deselectButton.Size = new System.Drawing.Size(23, 22);
            this.deselectButton.Text = "Erase";
            this.deselectButton.ToolTipText = "Erase";
            this.deselectButton.CheckedChanged += new System.EventHandler(this.deselectButton_CheckedChanged);
            // 
            // widthBox
            // 
            this.widthBox.Enabled = false;
            this.widthBox.MaxLength = 3;
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(25, 25);
            this.widthBox.Text = "1";
            this.widthBox.ToolTipText = "Width";
            this.widthBox.TextChanged += new System.EventHandler(this.WidthBox_TextChanged);
            // 
            // SelectionToolStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.toolStrip);
            this.Name = "SelectionToolStrip";
            this.Size = new System.Drawing.Size(290, 41);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton boxAlignButton;
        private System.Windows.Forms.ToolStripButton boxButton;
        private System.Windows.Forms.ToolStripButton lineButton;
        private System.Windows.Forms.ToolStripButton pointButton;
        private System.Windows.Forms.ToolStripButton circleButton;
        private System.Windows.Forms.ToolStripButton deselectButton;
        private System.Windows.Forms.ToolStripButton fillButton;
        private System.Windows.Forms.ToolStripLabel widthLabel;
        private System.Windows.Forms.ToolStripTextBox widthBox;
    }
}
