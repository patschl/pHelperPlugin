namespace Turbo.plugins.patrick.forms.hotkeys
{
    using System.ComponentModel;

    partial class HotkeyPopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Press key! Escape to cancel.";
            // 
            // HotkeyPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 65);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximumSize = new System.Drawing.Size(184, 98);
            this.MinimumSize = new System.Drawing.Size(184, 98);
            this.Name = "HotkeyPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Press Key";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeypressPopup_KeyDown);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label1;

        #endregion
    }
}