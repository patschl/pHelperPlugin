namespace Turbo.plugins.patrick.forms.definitions
{
    using System.ComponentModel;

    partial class AddMasterProfile
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
            this.tb_ConfigProfileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.b_Save = new System.Windows.Forms.Button();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_ConfigProfileName
            // 
            this.tb_ConfigProfileName.Location = new System.Drawing.Point(126, 31);
            this.tb_ConfigProfileName.Name = "tb_ConfigProfileName";
            this.tb_ConfigProfileName.Size = new System.Drawing.Size(209, 20);
            this.tb_ConfigProfileName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(21, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Profile name:";
            // 
            // b_Save
            // 
            this.b_Save.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.b_Save.Location = new System.Drawing.Point(165, 73);
            this.b_Save.Name = "b_Save";
            this.b_Save.Size = new System.Drawing.Size(93, 28);
            this.b_Save.TabIndex = 2;
            this.b_Save.Text = "Save";
            this.b_Save.UseVisualStyleBackColor = true;
            this.b_Save.Click += new System.EventHandler(this.b_Save_Click);
            // 
            // b_Cancel
            // 
            this.b_Cancel.Location = new System.Drawing.Point(264, 73);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(93, 28);
            this.b_Cancel.TabIndex = 3;
            this.b_Cancel.Text = "Cancel";
            this.b_Cancel.UseVisualStyleBackColor = true;
            this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
            // 
            // AddMasterProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 113);
            this.ControlBox = false;
            this.Controls.Add(this.b_Cancel);
            this.Controls.Add(this.b_Save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_ConfigProfileName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddMasterProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Master Profile";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddMasterProfile_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button b_Cancel;
        private System.Windows.Forms.Button b_Save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ConfigProfileName;

        #endregion
    }
}