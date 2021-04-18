namespace Turbo.Plugins.Patrick.forms
{
    using System.ComponentModel;

    partial class Settings
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
            this.main = new System.Windows.Forms.TabControl();
            this.tab_SkillEditor = new System.Windows.Forms.TabPage();
            this.cb_ConfigProfile = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cb_SkillActive = new System.Windows.Forms.CheckBox();
            this.b_DeleteSkillFromDefinitionGroups = new System.Windows.Forms.Button();
            this.b_DeleteDefinitionGroup = new System.Windows.Forms.Button();
            this.cb_DefinitionGroupActive = new System.Windows.Forms.CheckBox();
            this.b_EditDefinitionGroup = new System.Windows.Forms.Button();
            this.b_AddNewDefinitionGroup = new System.Windows.Forms.Button();
            this.tb_DefintionGroupName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.b_AddSkill = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_Skills = new System.Windows.Forms.ComboBox();
            this.cb_ClassFilter = new System.Windows.Forms.ComboBox();
            this.lb_DefinitionGroupsForSkill = new System.Windows.Forms.ListBox();
            this.lb_skillsWithDefinitionGroups = new System.Windows.Forms.ListBox();
            this.cb_ShowOnlyForCurrentClass = new System.Windows.Forms.CheckBox();
            this.tab_Hotkeys = new System.Windows.Forms.TabPage();
            this.dgv_Hotkeys = new System.Windows.Forms.DataGridView();
            this.tab_AutoActions = new System.Windows.Forms.TabPage();
            this.dgv_AutoActions = new System.Windows.Forms.DataGridView();
            this.tab_Settings = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.cb_LogLevel = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_Potion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Qol = new System.Windows.Forms.ComboBox();
            this.cb_Map = new System.Windows.Forms.ComboBox();
            this.cb_CloseWindows = new System.Windows.Forms.ComboBox();
            this.cb_Skill3 = new System.Windows.Forms.ComboBox();
            this.cb_Skill4 = new System.Windows.Forms.ComboBox();
            this.cb_ForceStand = new System.Windows.Forms.ComboBox();
            this.cb_ForceMove = new System.Windows.Forms.ComboBox();
            this.cb_Skill2 = new System.Windows.Forms.ComboBox();
            this.cb_Skill1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pb_Donate = new System.Windows.Forms.PictureBox();
            this.main.SuspendLayout();
            this.tab_SkillEditor.SuspendLayout();
            this.tab_Hotkeys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dgv_Hotkeys)).BeginInit();
            this.tab_AutoActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dgv_AutoActions)).BeginInit();
            this.tab_Settings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pb_Donate)).BeginInit();
            this.SuspendLayout();
            // 
            // main
            // 
            this.main.Controls.Add(this.tab_SkillEditor);
            this.main.Controls.Add(this.tab_Hotkeys);
            this.main.Controls.Add(this.tab_AutoActions);
            this.main.Controls.Add(this.tab_Settings);
            this.main.Location = new System.Drawing.Point(0, 0);
            this.main.Name = "main";
            this.main.SelectedIndex = 0;
            this.main.Size = new System.Drawing.Size(666, 510);
            this.main.TabIndex = 0;
            // 
            // tab_SkillEditor
            // 
            this.tab_SkillEditor.Controls.Add(this.cb_ConfigProfile);
            this.tab_SkillEditor.Controls.Add(this.label16);
            this.tab_SkillEditor.Controls.Add(this.cb_SkillActive);
            this.tab_SkillEditor.Controls.Add(this.b_DeleteSkillFromDefinitionGroups);
            this.tab_SkillEditor.Controls.Add(this.b_DeleteDefinitionGroup);
            this.tab_SkillEditor.Controls.Add(this.cb_DefinitionGroupActive);
            this.tab_SkillEditor.Controls.Add(this.b_EditDefinitionGroup);
            this.tab_SkillEditor.Controls.Add(this.b_AddNewDefinitionGroup);
            this.tab_SkillEditor.Controls.Add(this.tb_DefintionGroupName);
            this.tab_SkillEditor.Controls.Add(this.label13);
            this.tab_SkillEditor.Controls.Add(this.b_AddSkill);
            this.tab_SkillEditor.Controls.Add(this.label12);
            this.tab_SkillEditor.Controls.Add(this.label7);
            this.tab_SkillEditor.Controls.Add(this.cb_Skills);
            this.tab_SkillEditor.Controls.Add(this.cb_ClassFilter);
            this.tab_SkillEditor.Controls.Add(this.lb_DefinitionGroupsForSkill);
            this.tab_SkillEditor.Controls.Add(this.lb_skillsWithDefinitionGroups);
            this.tab_SkillEditor.Controls.Add(this.cb_ShowOnlyForCurrentClass);
            this.tab_SkillEditor.Location = new System.Drawing.Point(4, 22);
            this.tab_SkillEditor.Name = "tab_SkillEditor";
            this.tab_SkillEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tab_SkillEditor.Size = new System.Drawing.Size(658, 484);
            this.tab_SkillEditor.TabIndex = 0;
            this.tab_SkillEditor.Text = "Skill Editor";
            this.tab_SkillEditor.UseVisualStyleBackColor = true;
            // 
            // cb_ConfigProfile
            // 
            this.cb_ConfigProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ConfigProfile.FormattingEnabled = true;
            this.cb_ConfigProfile.Location = new System.Drawing.Point(289, 110);
            this.cb_ConfigProfile.Name = "cb_ConfigProfile";
            this.cb_ConfigProfile.Size = new System.Drawing.Size(156, 21);
            this.cb_ConfigProfile.TabIndex = 21;
            this.cb_ConfigProfile.SelectedIndexChanged += new System.EventHandler(this.cb_ConfigProfile_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(217, 113);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(127, 24);
            this.label16.TabIndex = 20;
            this.label16.Text = "Config Profile:";
            // 
            // cb_SkillActive
            // 
            this.cb_SkillActive.Location = new System.Drawing.Point(76, 329);
            this.cb_SkillActive.Name = "cb_SkillActive";
            this.cb_SkillActive.Size = new System.Drawing.Size(83, 39);
            this.cb_SkillActive.TabIndex = 15;
            this.cb_SkillActive.Text = "Skill Active";
            this.cb_SkillActive.UseVisualStyleBackColor = true;
            this.cb_SkillActive.CheckedChanged += new System.EventHandler(this.cb_SkillActive_CheckedChanged);
            // 
            // b_DeleteSkillFromDefinitionGroups
            // 
            this.b_DeleteSkillFromDefinitionGroups.Location = new System.Drawing.Point(209, 39);
            this.b_DeleteSkillFromDefinitionGroups.Name = "b_DeleteSkillFromDefinitionGroups";
            this.b_DeleteSkillFromDefinitionGroups.Size = new System.Drawing.Size(23, 26);
            this.b_DeleteSkillFromDefinitionGroups.TabIndex = 14;
            this.b_DeleteSkillFromDefinitionGroups.Text = "X";
            this.b_DeleteSkillFromDefinitionGroups.UseVisualStyleBackColor = true;
            this.b_DeleteSkillFromDefinitionGroups.Click += new System.EventHandler(this.b_DeleteSkillFromDefinitionGroups_Click);
            // 
            // b_DeleteDefinitionGroup
            // 
            this.b_DeleteDefinitionGroup.Location = new System.Drawing.Point(626, 39);
            this.b_DeleteDefinitionGroup.Name = "b_DeleteDefinitionGroup";
            this.b_DeleteDefinitionGroup.Size = new System.Drawing.Size(23, 26);
            this.b_DeleteDefinitionGroup.TabIndex = 13;
            this.b_DeleteDefinitionGroup.Text = "X";
            this.b_DeleteDefinitionGroup.UseVisualStyleBackColor = true;
            this.b_DeleteDefinitionGroup.Click += new System.EventHandler(this.b_DeleteDefinitionGroup_Click);
            // 
            // cb_DefinitionGroupActive
            // 
            this.cb_DefinitionGroupActive.Location = new System.Drawing.Point(472, 335);
            this.cb_DefinitionGroupActive.Name = "cb_DefinitionGroupActive";
            this.cb_DefinitionGroupActive.Size = new System.Drawing.Size(138, 39);
            this.cb_DefinitionGroupActive.TabIndex = 12;
            this.cb_DefinitionGroupActive.Text = "Definition Group Active";
            this.cb_DefinitionGroupActive.UseVisualStyleBackColor = true;
            this.cb_DefinitionGroupActive.CheckedChanged += new System.EventHandler(this.cb_DefinitionGroupActive_CheckedChanged);
            // 
            // b_EditDefinitionGroup
            // 
            this.b_EditDefinitionGroup.Location = new System.Drawing.Point(497, 433);
            this.b_EditDefinitionGroup.Name = "b_EditDefinitionGroup";
            this.b_EditDefinitionGroup.Size = new System.Drawing.Size(123, 32);
            this.b_EditDefinitionGroup.TabIndex = 11;
            this.b_EditDefinitionGroup.Text = "Edit Definition Group";
            this.b_EditDefinitionGroup.UseVisualStyleBackColor = true;
            this.b_EditDefinitionGroup.Click += new System.EventHandler(this.b_EditDefinitionGroup_Click);
            // 
            // b_AddNewDefinitionGroup
            // 
            this.b_AddNewDefinitionGroup.Location = new System.Drawing.Point(269, 287);
            this.b_AddNewDefinitionGroup.Name = "b_AddNewDefinitionGroup";
            this.b_AddNewDefinitionGroup.Size = new System.Drawing.Size(139, 42);
            this.b_AddNewDefinitionGroup.TabIndex = 10;
            this.b_AddNewDefinitionGroup.Text = "Add new definition group";
            this.b_AddNewDefinitionGroup.UseVisualStyleBackColor = true;
            this.b_AddNewDefinitionGroup.Click += new System.EventHandler(this.b_AddNewDefinitionGroup_Click);
            // 
            // tb_DefintionGroupName
            // 
            this.tb_DefintionGroupName.Location = new System.Drawing.Point(269, 244);
            this.tb_DefintionGroupName.Name = "tb_DefintionGroupName";
            this.tb_DefintionGroupName.Size = new System.Drawing.Size(156, 20);
            this.tb_DefintionGroupName.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(230, 247);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 24);
            this.label13.TabIndex = 8;
            this.label13.Text = "Name:";
            // 
            // b_AddSkill
            // 
            this.b_AddSkill.Location = new System.Drawing.Point(90, 433);
            this.b_AddSkill.Name = "b_AddSkill";
            this.b_AddSkill.Size = new System.Drawing.Size(82, 32);
            this.b_AddSkill.TabIndex = 7;
            this.b_AddSkill.Text = "Add skill";
            this.b_AddSkill.UseVisualStyleBackColor = true;
            this.b_AddSkill.Click += new System.EventHandler(this.b_addSkillToDefinitionGroups);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label12.Location = new System.Drawing.Point(25, 407);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 23);
            this.label12.TabIndex = 6;
            this.label12.Text = "Skill:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label7.Location = new System.Drawing.Point(25, 375);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 23);
            this.label7.TabIndex = 5;
            this.label7.Text = "Filter:";
            // 
            // cb_Skills
            // 
            this.cb_Skills.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Skills.FormattingEnabled = true;
            this.cb_Skills.Location = new System.Drawing.Point(76, 403);
            this.cb_Skills.Name = "cb_Skills";
            this.cb_Skills.Size = new System.Drawing.Size(113, 21);
            this.cb_Skills.TabIndex = 4;
            // 
            // cb_ClassFilter
            // 
            this.cb_ClassFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ClassFilter.FormattingEnabled = true;
            this.cb_ClassFilter.Location = new System.Drawing.Point(76, 374);
            this.cb_ClassFilter.Name = "cb_ClassFilter";
            this.cb_ClassFilter.Size = new System.Drawing.Size(113, 21);
            this.cb_ClassFilter.TabIndex = 3;
            this.cb_ClassFilter.SelectedIndexChanged += new System.EventHandler(this.cb_ClassFilterChanged);
            // 
            // lb_DefinitionGroupsForSkill
            // 
            this.lb_DefinitionGroupsForSkill.FormattingEnabled = true;
            this.lb_DefinitionGroupsForSkill.Location = new System.Drawing.Point(451, 39);
            this.lb_DefinitionGroupsForSkill.Name = "lb_DefinitionGroupsForSkill";
            this.lb_DefinitionGroupsForSkill.Size = new System.Drawing.Size(169, 290);
            this.lb_DefinitionGroupsForSkill.TabIndex = 2;
            this.lb_DefinitionGroupsForSkill.SelectedIndexChanged += new System.EventHandler(this.lb_DefinitionGroupsForSkill_SelectedIndexChanged);
            this.lb_DefinitionGroupsForSkill.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lb_DefinitionGroupsForSkill_MouseDoubleClick);
            // 
            // lb_skillsWithDefinitionGroups
            // 
            this.lb_skillsWithDefinitionGroups.FormattingEnabled = true;
            this.lb_skillsWithDefinitionGroups.Location = new System.Drawing.Point(25, 39);
            this.lb_skillsWithDefinitionGroups.Name = "lb_skillsWithDefinitionGroups";
            this.lb_skillsWithDefinitionGroups.Size = new System.Drawing.Size(178, 290);
            this.lb_skillsWithDefinitionGroups.TabIndex = 1;
            this.lb_skillsWithDefinitionGroups.SelectedIndexChanged += new System.EventHandler(this.lb_skillsWithDefinitionGroups_SelectedIndexChanged);
            // 
            // cb_ShowOnlyForCurrentClass
            // 
            this.cb_ShowOnlyForCurrentClass.Checked = true;
            this.cb_ShowOnlyForCurrentClass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ShowOnlyForCurrentClass.Location = new System.Drawing.Point(52, 9);
            this.cb_ShowOnlyForCurrentClass.Name = "cb_ShowOnlyForCurrentClass";
            this.cb_ShowOnlyForCurrentClass.Size = new System.Drawing.Size(151, 24);
            this.cb_ShowOnlyForCurrentClass.TabIndex = 0;
            this.cb_ShowOnlyForCurrentClass.Text = "Show only current class";
            this.cb_ShowOnlyForCurrentClass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb_ShowOnlyForCurrentClass.UseVisualStyleBackColor = true;
            this.cb_ShowOnlyForCurrentClass.CheckedChanged += new System.EventHandler(this.cb_ShowOnlyForCurrentClass_CheckedChanged);
            // 
            // tab_Hotkeys
            // 
            this.tab_Hotkeys.Controls.Add(this.dgv_Hotkeys);
            this.tab_Hotkeys.Location = new System.Drawing.Point(4, 22);
            this.tab_Hotkeys.Name = "tab_Hotkeys";
            this.tab_Hotkeys.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Hotkeys.Size = new System.Drawing.Size(658, 484);
            this.tab_Hotkeys.TabIndex = 2;
            this.tab_Hotkeys.Text = "Hotkeys";
            this.tab_Hotkeys.UseVisualStyleBackColor = true;
            // 
            // dgv_Hotkeys
            // 
            this.dgv_Hotkeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Hotkeys.Location = new System.Drawing.Point(0, 0);
            this.dgv_Hotkeys.Name = "dgv_Hotkeys";
            this.dgv_Hotkeys.Size = new System.Drawing.Size(657, 488);
            this.dgv_Hotkeys.TabIndex = 0;
            // 
            // tab_AutoActions
            // 
            this.tab_AutoActions.Controls.Add(this.dgv_AutoActions);
            this.tab_AutoActions.Location = new System.Drawing.Point(4, 22);
            this.tab_AutoActions.Name = "tab_AutoActions";
            this.tab_AutoActions.Padding = new System.Windows.Forms.Padding(3);
            this.tab_AutoActions.Size = new System.Drawing.Size(658, 484);
            this.tab_AutoActions.TabIndex = 3;
            this.tab_AutoActions.Text = "Auto Actions";
            this.tab_AutoActions.UseVisualStyleBackColor = true;
            // 
            // dgv_AutoActions
            // 
            this.dgv_AutoActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AutoActions.Location = new System.Drawing.Point(0, 0);
            this.dgv_AutoActions.Name = "dgv_AutoActions";
            this.dgv_AutoActions.Size = new System.Drawing.Size(657, 488);
            this.dgv_AutoActions.TabIndex = 0;
            // 
            // tab_Settings
            // 
            this.tab_Settings.Controls.Add(this.label14);
            this.tab_Settings.Controls.Add(this.cb_LogLevel);
            this.tab_Settings.Controls.Add(this.groupBox1);
            this.tab_Settings.Location = new System.Drawing.Point(4, 22);
            this.tab_Settings.Name = "tab_Settings";
            this.tab_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Settings.Size = new System.Drawing.Size(658, 484);
            this.tab_Settings.TabIndex = 1;
            this.tab_Settings.Text = "Settings";
            this.tab_Settings.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label14.Location = new System.Drawing.Point(1, 458);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 25);
            this.label14.TabIndex = 9;
            this.label14.Text = "LogLevel";
            // 
            // cb_LogLevel
            // 
            this.cb_LogLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_LogLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cb_LogLevel.FormattingEnabled = true;
            this.cb_LogLevel.Location = new System.Drawing.Point(81, 457);
            this.cb_LogLevel.Name = "cb_LogLevel";
            this.cb_LogLevel.Size = new System.Drawing.Size(90, 23);
            this.cb_LogLevel.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_Potion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cb_Qol);
            this.groupBox1.Controls.Add(this.cb_Map);
            this.groupBox1.Controls.Add(this.cb_CloseWindows);
            this.groupBox1.Controls.Add(this.cb_Skill3);
            this.groupBox1.Controls.Add(this.cb_Skill4);
            this.groupBox1.Controls.Add(this.cb_ForceStand);
            this.groupBox1.Controls.Add(this.cb_ForceMove);
            this.groupBox1.Controls.Add(this.cb_Skill2);
            this.groupBox1.Controls.Add(this.cb_Skill1);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 275);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Keybinds";
            // 
            // cb_Potion
            // 
            this.cb_Potion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Potion.FormattingEnabled = true;
            this.cb_Potion.ItemHeight = 13;
            this.cb_Potion.Items.AddRange(new object[] {"LMB", "RMB", "MMB", "MOUSE4", "MOUSE5", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "SHIFT", "SPACE", "CONTROL", "ALT", "TAB"});
            this.cb_Potion.Location = new System.Drawing.Point(114, 217);
            this.cb_Potion.Name = "cb_Potion";
            this.cb_Potion.Size = new System.Drawing.Size(77, 21);
            this.cb_Potion.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(6, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "Potion";
            // 
            // cb_Qol
            // 
            this.cb_Qol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Qol.FormattingEnabled = true;
            this.cb_Qol.ItemHeight = 13;
            this.cb_Qol.Items.AddRange(new object[] {"LMB", "RMB", "MMB", "MOUSE4", "MOUSE5", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "SHIFT", "SPACE", "CONTROL", "ALT", "TAB"});
            this.cb_Qol.Location = new System.Drawing.Point(114, 244);
            this.cb_Qol.Name = "cb_Qol";
            this.cb_Qol.Size = new System.Drawing.Size(77, 21);
            this.cb_Qol.TabIndex = 17;
            // 
            // cb_Map
            // 
            this.cb_Map.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Map.FormattingEnabled = true;
            this.cb_Map.ItemHeight = 13;
            this.cb_Map.Items.AddRange(new object[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "SHIFT", "SPACE", "CONTROL", "ALT", "TAB"});
            this.cb_Map.Location = new System.Drawing.Point(114, 190);
            this.cb_Map.Name = "cb_Map";
            this.cb_Map.Size = new System.Drawing.Size(77, 21);
            this.cb_Map.TabIndex = 16;
            // 
            // cb_CloseWindows
            // 
            this.cb_CloseWindows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CloseWindows.FormattingEnabled = true;
            this.cb_CloseWindows.ItemHeight = 13;
            this.cb_CloseWindows.Items.AddRange(new object[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "SHIFT", "SPACE", "CONTROL", "ALT", "TAB"});
            this.cb_CloseWindows.Location = new System.Drawing.Point(114, 165);
            this.cb_CloseWindows.Name = "cb_CloseWindows";
            this.cb_CloseWindows.Size = new System.Drawing.Size(77, 21);
            this.cb_CloseWindows.TabIndex = 15;
            // 
            // cb_Skill3
            // 
            this.cb_Skill3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Skill3.FormattingEnabled = true;
            this.cb_Skill3.ItemHeight = 13;
            this.cb_Skill3.Items.AddRange(new object[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "SHIFT", "SPACE", "CONTROL", "ALT", "TAB"});
            this.cb_Skill3.Location = new System.Drawing.Point(114, 65);
            this.cb_Skill3.Name = "cb_Skill3";
            this.cb_Skill3.Size = new System.Drawing.Size(77, 21);
            this.cb_Skill3.TabIndex = 14;
            // 
            // cb_Skill4
            // 
            this.cb_Skill4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Skill4.FormattingEnabled = true;
            this.cb_Skill4.ItemHeight = 13;
            this.cb_Skill4.Items.AddRange(new object[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "SHIFT", "SPACE", "CONTROL", "ALT", "TAB"});
            this.cb_Skill4.Location = new System.Drawing.Point(114, 90);
            this.cb_Skill4.Name = "cb_Skill4";
            this.cb_Skill4.Size = new System.Drawing.Size(77, 21);
            this.cb_Skill4.TabIndex = 13;
            // 
            // cb_ForceStand
            // 
            this.cb_ForceStand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ForceStand.FormattingEnabled = true;
            this.cb_ForceStand.ItemHeight = 13;
            this.cb_ForceStand.Items.AddRange(new object[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "SHIFT", "SPACE", "CONTROL", "ALT", "TAB"});
            this.cb_ForceStand.Location = new System.Drawing.Point(114, 115);
            this.cb_ForceStand.Name = "cb_ForceStand";
            this.cb_ForceStand.Size = new System.Drawing.Size(77, 21);
            this.cb_ForceStand.TabIndex = 12;
            // 
            // cb_ForceMove
            // 
            this.cb_ForceMove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ForceMove.FormattingEnabled = true;
            this.cb_ForceMove.ItemHeight = 13;
            this.cb_ForceMove.Items.AddRange(new object[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "SHIFT", "SPACE", "CONTROL", "ALT", "TAB"});
            this.cb_ForceMove.Location = new System.Drawing.Point(114, 140);
            this.cb_ForceMove.Name = "cb_ForceMove";
            this.cb_ForceMove.Size = new System.Drawing.Size(77, 21);
            this.cb_ForceMove.TabIndex = 11;
            // 
            // cb_Skill2
            // 
            this.cb_Skill2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Skill2.FormattingEnabled = true;
            this.cb_Skill2.ItemHeight = 13;
            this.cb_Skill2.Items.AddRange(new object[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "SHIFT", "SPACE", "CONTROL", "ALT", "TAB"});
            this.cb_Skill2.Location = new System.Drawing.Point(113, 40);
            this.cb_Skill2.Name = "cb_Skill2";
            this.cb_Skill2.Size = new System.Drawing.Size(77, 21);
            this.cb_Skill2.TabIndex = 10;
            // 
            // cb_Skill1
            // 
            this.cb_Skill1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Skill1.FormattingEnabled = true;
            this.cb_Skill1.ItemHeight = 13;
            this.cb_Skill1.Items.AddRange(new object[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "SHIFT", "SPACE", "CONTROL", "ALT", "TAB"});
            this.cb_Skill1.Location = new System.Drawing.Point(113, 15);
            this.cb_Skill1.Name = "cb_Skill1";
            this.cb_Skill1.Size = new System.Drawing.Size(77, 21);
            this.cb_Skill1.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label11.Location = new System.Drawing.Point(6, 16);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label11.Size = new System.Drawing.Size(102, 25);
            this.label11.TabIndex = 9;
            this.label11.Text = "Skill 1";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label10.Location = new System.Drawing.Point(6, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 25);
            this.label10.TabIndex = 8;
            this.label10.Text = "Skill 2";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label9.Location = new System.Drawing.Point(6, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 25);
            this.label9.TabIndex = 7;
            this.label9.Text = "Skill 3";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label8.Location = new System.Drawing.Point(6, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 25);
            this.label8.TabIndex = 6;
            this.label8.Text = "Force Stand";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label6.Location = new System.Drawing.Point(6, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "QoL Key";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label5.Location = new System.Drawing.Point(6, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Close Windows";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label4.Location = new System.Drawing.Point(6, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Skill 4";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label3.Location = new System.Drawing.Point(6, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Force Move";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.Location = new System.Drawing.Point(6, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Map";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label15.Location = new System.Drawing.Point(0, 509);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(666, 22);
            this.label15.TabIndex = 1;
            this.label15.Text = "© patrick#7777";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_Donate
            // 
            this.pb_Donate.Location = new System.Drawing.Point(589, 509);
            this.pb_Donate.Name = "pb_Donate";
            this.pb_Donate.Size = new System.Drawing.Size(77, 22);
            this.pb_Donate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Donate.TabIndex = 16;
            this.pb_Donate.TabStop = false;
            this.pb_Donate.Click += new System.EventHandler(this.pb_Donate_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 529);
            this.Controls.Add(this.pb_Donate);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.RightToLeftLayout = true;
            this.Text = "pHelper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.main.ResumeLayout(false);
            this.tab_SkillEditor.ResumeLayout(false);
            this.tab_SkillEditor.PerformLayout();
            this.tab_Hotkeys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.dgv_Hotkeys)).EndInit();
            this.tab_AutoActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.dgv_AutoActions)).EndInit();
            this.tab_Settings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pb_Donate)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button b_AddNewDefinitionGroup;
        private System.Windows.Forms.Button b_AddSkill;
        private System.Windows.Forms.Button b_DeleteDefinitionGroup;
        private System.Windows.Forms.Button b_DeleteSkillFromDefinitionGroups;
        private System.Windows.Forms.Button b_EditDefinitionGroup;
        private System.Windows.Forms.ComboBox cb_ClassFilter;
        private System.Windows.Forms.ComboBox cb_CloseWindows;
        private System.Windows.Forms.ComboBox cb_ConfigProfile;
        private System.Windows.Forms.CheckBox cb_DefinitionGroupActive;
        private System.Windows.Forms.ComboBox cb_ForceMove;
        private System.Windows.Forms.ComboBox cb_ForceStand;
        private System.Windows.Forms.ComboBox cb_LogLevel;
        private System.Windows.Forms.ComboBox cb_Map;
        private System.Windows.Forms.ComboBox cb_Potion;
        private System.Windows.Forms.ComboBox cb_Qol;
        private System.Windows.Forms.CheckBox cb_ShowOnlyForCurrentClass;
        private System.Windows.Forms.ComboBox cb_Skill1;
        private System.Windows.Forms.ComboBox cb_Skill2;
        private System.Windows.Forms.ComboBox cb_Skill3;
        private System.Windows.Forms.ComboBox cb_Skill4;
        private System.Windows.Forms.CheckBox cb_SkillActive;
        private System.Windows.Forms.ComboBox cb_Skills;
        private System.Windows.Forms.DataGridView dgv_AutoActions;
        private System.Windows.Forms.DataGridView dgv_Hotkeys;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lb_DefinitionGroupsForSkill;
        private System.Windows.Forms.ListBox lb_skillsWithDefinitionGroups;
        private System.Windows.Forms.TabControl main;
        private System.Windows.Forms.PictureBox pb_Donate;
        private System.Windows.Forms.TabPage tab_AutoActions;
        private System.Windows.Forms.TabPage tab_Hotkeys;
        private System.Windows.Forms.TabPage tab_Settings;
        private System.Windows.Forms.TabPage tab_SkillEditor;
        private System.Windows.Forms.TextBox tb_DefintionGroupName;

        #endregion
    }
}