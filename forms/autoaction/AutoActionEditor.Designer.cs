namespace Turbo.plugins.patrick.forms.autoaction
{
    using System.ComponentModel;

    partial class AutoActionEditor
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
            this.b_Save = new System.Windows.Forms.Button();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.l_AutoActionName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // b_Save
            // 
            this.b_Save.Location = new System.Drawing.Point(175, 90);
            this.b_Save.Name = "b_Save";
            this.b_Save.Size = new System.Drawing.Size(94, 40);
            this.b_Save.TabIndex = 7;
            this.b_Save.Text = "Save";
            this.b_Save.UseVisualStyleBackColor = true;
            this.b_Save.Click += new System.EventHandler(this.b_Save_Click);
            // 
            // b_Cancel
            // 
            this.b_Cancel.Location = new System.Drawing.Point(284, 90);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(94, 40);
            this.b_Cancel.TabIndex = 6;
            this.b_Cancel.Text = "Cancel";
            this.b_Cancel.UseVisualStyleBackColor = true;
            this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
            // 
            // l_AutoActionName
            // 
            this.l_AutoActionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.l_AutoActionName.Location = new System.Drawing.Point(24, 9);
            this.l_AutoActionName.Name = "l_AutoActionName";
            this.l_AutoActionName.Size = new System.Drawing.Size(343, 49);
            this.l_AutoActionName.TabIndex = 8;
            this.l_AutoActionName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutoActionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 142);
            this.Controls.Add(this.l_AutoActionName);
            this.Controls.Add(this.b_Save);
            this.Controls.Add(this.b_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AutoActionEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AutoActionEditor";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button b_Cancel;
        private System.Windows.Forms.Button b_Save;
        private System.Windows.Forms.Label l_AutoActionName;

        #endregion
    }
}