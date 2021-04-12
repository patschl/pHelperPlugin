namespace Turbo.plugins.patrick.forms.definitions
{
    using System.ComponentModel;

    partial class DefinitionGroupEditor
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
            this.dgv_Definitions = new System.Windows.Forms.DataGridView();
            this.b_Close = new System.Windows.Forms.Button();
            this.b_AddDefinition = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.dgv_Definitions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Definitions
            // 
            this.dgv_Definitions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Definitions.Location = new System.Drawing.Point(1, 1);
            this.dgv_Definitions.Name = "dgv_Definitions";
            this.dgv_Definitions.Size = new System.Drawing.Size(730, 310);
            this.dgv_Definitions.TabIndex = 0;
            // 
            // b_Close
            // 
            this.b_Close.Location = new System.Drawing.Point(611, 320);
            this.b_Close.Name = "b_Close";
            this.b_Close.Size = new System.Drawing.Size(102, 40);
            this.b_Close.TabIndex = 1;
            this.b_Close.Text = "Close";
            this.b_Close.UseVisualStyleBackColor = true;
            this.b_Close.Click += new System.EventHandler(this.b_Close_Click);
            // 
            // b_AddDefinition
            // 
            this.b_AddDefinition.Location = new System.Drawing.Point(12, 320);
            this.b_AddDefinition.Name = "b_AddDefinition";
            this.b_AddDefinition.Size = new System.Drawing.Size(102, 40);
            this.b_AddDefinition.TabIndex = 3;
            this.b_AddDefinition.Text = "Add Definition";
            this.b_AddDefinition.UseVisualStyleBackColor = true;
            this.b_AddDefinition.Click += new System.EventHandler(this.b_AddDefinition_Click);
            // 
            // DefinitionGroupEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 372);
            this.Controls.Add(this.b_AddDefinition);
            this.Controls.Add(this.b_Close);
            this.Controls.Add(this.dgv_Definitions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "DefinitionGroupEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Definition Group Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DefinitionGroupEditor_FormClosing);
            this.Load += new System.EventHandler(this.EditDefinitionGroup_Load);
            ((System.ComponentModel.ISupportInitialize) (this.dgv_Definitions)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button b_AddDefinition;
        private System.Windows.Forms.Button b_Close;
        private System.Windows.Forms.DataGridView dgv_Definitions;

        #endregion
    }
}