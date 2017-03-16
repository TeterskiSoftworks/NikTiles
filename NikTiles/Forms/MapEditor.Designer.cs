
namespace NikTiles.Forms
{
    partial class MapEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mapDisplay = new NikTiles.Forms.MapDisplay();
            this.SuspendLayout();
            // 
            // mapDisplay
            // 
            this.mapDisplay.Location = new System.Drawing.Point(12, 12);
            this.mapDisplay.Name = "mapDisplay";
            this.mapDisplay.Size = new System.Drawing.Size(276, 247);
            this.mapDisplay.TabIndex = 0;
            this.mapDisplay.Text = "mapDisplay1";
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 571);
            this.Controls.Add(this.mapDisplay);
            this.Name = "MapEditor";
            this.Text = "MapEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private MapDisplay mapDisplay;
    }
}