namespace NikTiles.Editor.Forms {
    partial class RewriteDialog {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cancelButton = new System.Windows.Forms.Button();
            this.rewriteButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(99, 92);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // rewriteButton
            // 
            this.rewriteButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.rewriteButton.Location = new System.Drawing.Point(14, 92);
            this.rewriteButton.Name = "rewriteButton";
            this.rewriteButton.Size = new System.Drawing.Size(75, 23);
            this.rewriteButton.TabIndex = 6;
            this.rewriteButton.Text = "Rewrite";
            this.rewriteButton.UseVisualStyleBackColor = true;
            // 
            // changeButton
            // 
            this.changeButton.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.changeButton.Location = new System.Drawing.Point(14, 63);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(160, 23);
            this.changeButton.TabIndex = 5;
            this.changeButton.Text = "Change Name";
            this.changeButton.UseVisualStyleBackColor = true;
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(11, 10);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(163, 46);
            this.label.TabIndex = 4;
            this.label.Text = "The name you entered is already in use. Do you wish to rewrite the file or choose" +
    " a new name?\r\n";
            this.label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RewriteDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 124);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.rewriteButton);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RewriteDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Attention!";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button rewriteButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Label label;
    }
}