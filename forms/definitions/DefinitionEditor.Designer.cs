namespace Turbo.plugins.patrick.forms.definitions
{
    using System.ComponentModel;

    partial class DefinitionEditor
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
            this.cb_DefinitionType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Inverted = new System.Windows.Forms.CheckBox();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.b_Save = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_Group = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cb_DefinitionType
            // 
            this.cb_DefinitionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_DefinitionType.FormattingEnabled = true;
            this.cb_DefinitionType.Location = new System.Drawing.Point(127, 80);
            this.cb_DefinitionType.Name = "cb_DefinitionType";
            this.cb_DefinitionType.Size = new System.Drawing.Size(226, 21);
            this.cb_DefinitionType.TabIndex = 0;
            this.cb_DefinitionType.SelectedIndexChanged += new System.EventHandler(this.cb_DefinitionType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Definition Type";
            // 
            // cb_Inverted
            // 
            this.cb_Inverted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cb_Inverted.Location = new System.Drawing.Point(372, 72);
            this.cb_Inverted.Name = "cb_Inverted";
            this.cb_Inverted.Size = new System.Drawing.Size(106, 34);
            this.cb_Inverted.TabIndex = 3;
            this.cb_Inverted.Text = "Inverted";
            this.cb_Inverted.UseVisualStyleBackColor = true;
            // 
            // b_Cancel
            // 
            this.b_Cancel.Location = new System.Drawing.Point(372, 120);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(94, 40);
            this.b_Cancel.TabIndex = 4;
            this.b_Cancel.Text = "Cancel";
            this.b_Cancel.UseVisualStyleBackColor = true;
            this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
            // 
            // b_Save
            // 
            this.b_Save.Location = new System.Drawing.Point(263, 120);
            this.b_Save.Name = "b_Save";
            this.b_Save.Size = new System.Drawing.Size(94, 40);
            this.b_Save.TabIndex = 5;
            this.b_Save.Text = "Save";
            this.b_Save.UseVisualStyleBackColor = true;
            this.b_Save.Click += new System.EventHandler(this.b_Save_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Group";
            // 
            // cb_Group
            // 
            this.cb_Group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Group.FormattingEnabled = true;
            this.cb_Group.Location = new System.Drawing.Point(127, 40);
            this.cb_Group.Name = "cb_Group";
            this.cb_Group.Size = new System.Drawing.Size(139, 21);
            this.cb_Group.TabIndex = 6;
            this.cb_Group.SelectedIndexChanged += new System.EventHandler(this.cb_Group_SelectedIndexChanged);
            // 
            // DefinitionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 182);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_Group);
            this.Controls.Add(this.b_Save);
            this.Controls.Add(this.b_Cancel);
            this.Controls.Add(this.cb_Inverted);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_DefinitionType);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "DefinitionEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Definition Editor";
            this.Load += new System.EventHandler(this.DefinitionEditor_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button b_Cancel;
        private System.Windows.Forms.Button b_Save;
        private System.Windows.Forms.ComboBox cb_DefinitionType;
        private System.Windows.Forms.ComboBox cb_Group;
        private System.Windows.Forms.CheckBox cb_Inverted;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        #endregion
    }
}