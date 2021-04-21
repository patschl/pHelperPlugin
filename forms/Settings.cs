namespace Turbo.Plugins.Patrick.forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using autoactions;
    using Default;
    using hotkeys;
    using plugins.patrick.autoactions.actions;
    using plugins.patrick.forms.autoaction;
    using plugins.patrick.forms.definitions;
    using plugins.patrick.forms.hotkeys;
    using plugins.patrick.hotkeys.actions;
    using plugins.patrick.skills;
    using plugins.patrick.util.config;
    using plugins.patrick.util.input;
    using plugins.patrick.util.logger;
    using plugins.patrick.util.winformutil;
    using util;

    public partial class Settings : Form
    {
        public readonly IController Hud;

        public static Dictionary<int, Keys> Keybinds;
        
        public static volatile Dictionary<ActionKey, bool> KeyToActive = new Dictionary<ActionKey, bool>
        {
            {ActionKey.LeftSkill, true},
            {ActionKey.RightSkill, true},
            {ActionKey.Skill1, true},
            {ActionKey.Skill2, true},
            {ActionKey.Skill3, true},
            {ActionKey.Skill4, true}
        };
        
        public static volatile bool Active = true;

        private Dictionary<string, Dictionary<uint, DefinitionGroupsForSkill>> profileToSkillDefinitionGroups;
        
        public Dictionary<uint, DefinitionGroupsForSkill> SnoToDefinitionGroups;

        public HotkeyContainer Hotkeys;

        public AutoActionContainer AutoActions;

        public static readonly Dictionary<HeroClass, List<ISnoPower>> HeroClassToSnoPowers = new Dictionary<HeroClass, List<ISnoPower>>();

        private BindingList<ISnoPower> skillsWithDefinitionGroupsDisplayValues = new BindingList<ISnoPower>();
        
        private BindingList<string> masterProfileNames = new BindingList<string>();

        private BindingList<DefinitionGroup> selectedSkillDefinitionGroupsDisplayValues = new BindingList<DefinitionGroup>();

        private BindingSource hotkeyBinding;

        private BindingSource autoActionBinding;

        private readonly Dictionary<uint, HeroClass> snoPowerToHeroClass = new Dictionary<uint, HeroClass>();

        private const string SNO_POWER_LIST_ONLY_LEGENDARY_POWERS_PATTERN =
            "(Wizard_|Barbarian_|Necromancer_|Monk_|WitchDoctor_|DemonHunter_|Crusader_|Generic_)";
        
        public const string ADD_NEW_ITEM = "Add new...";

        public static Dictionary<string, ISnoPower> NameToSnoPower;

        public Settings(IController hud)
        {
            Hud = hud;

            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(@"plugins\patrick\resource\icon.ico");
            pb_Donate.Image = Image.FromFile(@"plugins\patrick\resource\donate.jpg");
        }

        private void OnLoad(object sender, EventArgs e)
        {
            InitializeLogger();
            LoadConfig();
            InitializeSkillEditor();
            InitializeHotkeys();
            InitializeAutoActions();
            InitializeSettings();

            var regex = new Regex(SNO_POWER_LIST_ONLY_LEGENDARY_POWERS_PATTERN);

            NameToSnoPower = Hud.Sno.SnoPowers.GetType().GetProperties()
                .Where(prop => !regex.IsMatch(prop.Name))
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(Hud.Sno.SnoPowers) as ISnoPower);
        }

        private void LoadConfig()
        {
            Keybinds = ConfigPersistence.LoadKeybinds();

            Hotkeys = ConfigPersistence.LoadHotkeyContainer();
            Hotkeys.InitializeIKeyEventsAndSort(Hud.Input);

            AutoActions = ConfigPersistence.LoadAutoActions();

            profileToSkillDefinitionGroups = ConfigPersistence.LoadMasterProfiles();

            SnoToDefinitionGroups = profileToSkillDefinitionGroups.FirstOrDefault().Value;
            SnoToDefinitionGroups.ForEach(def => skillsWithDefinitionGroupsDisplayValues.Add(Hud.Sno.GetSnoPower(def.Key)));
        }

        private void InitializeSettings()
        {
            InitializeKeybinds();
        }

        private void InitializeKeybinds()
        {
            cb_Skill1.DataSource = InputUtil.KeyboardKeys();
            cb_Skill1.SelectedItem = Keybinds[(int)ActionKey.Skill1];
            cb_Skill1.SelectedIndexChanged +=
                (sender, args) => ConfigPersistence.SetKeybindAndSaveConfig((int)ActionKey.Skill1, cb_Skill1);


            cb_Skill2.DataSource = InputUtil.KeyboardKeys();
            cb_Skill2.SelectedItem = Keybinds[(int)ActionKey.Skill2];
            cb_Skill2.SelectedIndexChanged +=
                (sender, args) => ConfigPersistence.SetKeybindAndSaveConfig((int)ActionKey.Skill2, cb_Skill2);

            cb_Skill3.DataSource = InputUtil.KeyboardKeys();
            cb_Skill3.SelectedItem = Keybinds[(int)ActionKey.Skill3];
            cb_Skill3.SelectedIndexChanged +=
                (sender, args) => ConfigPersistence.SetKeybindAndSaveConfig((int)ActionKey.Skill3, cb_Skill3);

            cb_Skill4.DataSource = InputUtil.KeyboardKeys();
            cb_Skill4.SelectedItem = Keybinds[(int)ActionKey.Skill4];
            cb_Skill4.SelectedIndexChanged +=
                (sender, args) => ConfigPersistence.SetKeybindAndSaveConfig((int)ActionKey.Skill4, cb_Skill4);

            cb_ForceStand.DataSource = InputUtil.KeyboardKeys();
            cb_ForceStand.SelectedItem = Keybinds[(int)ActionKey.Unknown];
            cb_ForceStand.SelectedIndexChanged +=
                (sender, args) => ConfigPersistence.SetKeybindAndSaveConfig((int)ActionKey.Unknown, cb_ForceStand);

            cb_ForceMove.DataSource = InputUtil.KeyboardKeys().Concat(InputUtil.MouseKeys()).ToList();
            cb_ForceMove.SelectedItem = Keybinds[(int)ActionKey.Move];
            cb_ForceMove.SelectedIndexChanged +=
                (sender, args) => ConfigPersistence.SetKeybindAndSaveConfig((int)ActionKey.Move, cb_ForceMove);

            cb_CloseWindows.DataSource = InputUtil.KeyboardKeys();
            cb_CloseWindows.SelectedItem = Keybinds[(int)ActionKey.Close];
            cb_CloseWindows.SelectedIndexChanged +=
                (sender, args) => ConfigPersistence.SetKeybindAndSaveConfig((int)ActionKey.Close, cb_CloseWindows);

            cb_Map.DataSource = InputUtil.KeyboardKeys();
            cb_Map.SelectedItem = Keybinds[(int)ActionKey.Map];
            cb_Map.SelectedIndexChanged +=
                (sender, args) => ConfigPersistence.SetKeybindAndSaveConfig((int)ActionKey.Map, cb_Map);

            cb_Potion.DataSource = InputUtil.KeyboardKeys();
            cb_Potion.SelectedItem = Keybinds[(int)ActionKey.Heal];
            cb_Potion.SelectedIndexChanged +=
                (sender, args) => ConfigPersistence.SetKeybindAndSaveConfig((int)ActionKey.Heal, cb_Potion);

            cb_Qol.DataSource = InputUtil.KeyboardKeys().Concat(InputUtil.MouseKeys()).ToList();
            cb_Qol.SelectedItem = Keybinds[ConfigPersistence.QOL_KEY_INDEX];
            cb_Qol.SelectedIndexChanged +=
                (sender, args) => ConfigPersistence.SetKeybindAndSaveConfig(ConfigPersistence.QOL_KEY_INDEX, cb_Qol);
        }

        private void InitializeLogger()
        {
            Logger.Initialize(Hud);

            cb_LogLevel.DataSource = Enum.GetValues(typeof(LogLevel)).Cast<LogLevel>();
            cb_LogLevel.SelectedIndexChanged += (sender, args) => Logger.LogLevel = (LogLevel)cb_LogLevel.SelectedItem;
        }

        private void InitializeSkillEditor()
        {
            InitializeComboBoxes();
            InitializeListBoxes();
            InitializeMasterProfiles();
            cb_ShowOnlyForCurrentClass_CheckedChanged(null, null);
        }

        private void ResetSkillEditor()
        {
            InitializeListBoxes();
            cb_ShowOnlyForCurrentClass_CheckedChanged(null, null);
        }

        private void InitializeComboBoxes()
        {
            var heroClasses = new List<HeroClass>
            {
                HeroClass.DemonHunter,
                HeroClass.Barbarian,
                HeroClass.Wizard,
                HeroClass.WitchDoctor,
                HeroClass.Monk,
                HeroClass.Crusader,
                HeroClass.Necromancer
            };
            foreach (var heroClass in heroClasses)
            {
                cb_ClassFilter.Items.Add(heroClass);

                var orderedHeroClassISnoPowers = Hud.Sno.SnoPowers.GetClassSpecificPowers(heroClass)
                    .Where(skill => skill.HasKnownRunesValues)
                    .OrderBy(skill => skill.NameEnglish)
                    .ToList();

                HeroClassToSnoPowers.Add(heroClass, orderedHeroClassISnoPowers);

                orderedHeroClassISnoPowers
                    .ForEach(sno => snoPowerToHeroClass.Add(sno.Sno, heroClass));
            }

            var allISnoPowers = HeroClassToSnoPowers
                .SelectMany(pair => pair.Value)
                .OrderBy(skill => skill.NameEnglish)
                .ToList();

            HeroClassToSnoPowers.Add(HeroClass.None, allISnoPowers);

            cb_ClassFilter.Items.Add(HeroClass.None);
            cb_ClassFilter.SelectedItem = HeroClass.None;

            cb_Skills.DataSource = HeroClassToSnoPowers[HeroClass.None];
            cb_Skills.DisplayMember = "NameEnglish";
            cb_Skills.SelectedIndex = 0;
        }

        private void InitializeListBoxes()
        {
            lb_skillsWithDefinitionGroups.DataSource = skillsWithDefinitionGroupsDisplayValues;
            lb_skillsWithDefinitionGroups.DisplayMember = "NameEnglish";

            lb_DefinitionGroupsForSkill.DataSource = selectedSkillDefinitionGroupsDisplayValues;
            lb_DefinitionGroupsForSkill.DisplayMember = "name";
        }

        private void InitializeMasterProfiles()
        {
            masterProfileNames = new BindingList<string>(profileToSkillDefinitionGroups.Keys.Concat(new[] {ADD_NEW_ITEM}).ToList());
            cb_MasterProfile.DataSource = masterProfileNames;
        }

        private void InitializeHotkeys()
        {
            dgv_Hotkeys.RowHeadersVisible = false;
            dgv_Hotkeys.AllowUserToAddRows = false;
            dgv_Hotkeys.AllowUserToResizeColumns = false;
            dgv_Hotkeys.AllowUserToResizeRows = false;
            dgv_Hotkeys.DefaultCellStyle.SelectionBackColor = dgv_Hotkeys.DefaultCellStyle.BackColor;
            dgv_Hotkeys.DefaultCellStyle.SelectionForeColor = dgv_Hotkeys.DefaultCellStyle.ForeColor;

            var columns = DgvFormUtil.GetHotkeysColumns();
            columns.ForEach(column => dgv_Hotkeys.Columns.Add(column));

            dgv_Hotkeys.CurrentCellDirtyStateChanged += (sender, args) =>
            {
                if (dgv_Hotkeys.IsCurrentCellDirty &&
                    dgv_Hotkeys.CurrentCell.OwningColumn == dgv_Hotkeys.Columns["active"]
                )
                {
                    dgv_Hotkeys.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };

            dgv_Hotkeys.CellContentClick += (sender, args) =>
            {
                if (args.RowIndex < 0 || args.ColumnIndex != dgv_Hotkeys.Columns["active"]?.Index)
                    return;

                var val = (DataGridViewCheckBoxCell)dgv_Hotkeys.Rows[args.RowIndex].Cells["active"];
                var isChecked = Convert.ToBoolean(val.Value);

                var hotkey = (AbstractHotkeyAction)dgv_Hotkeys.Rows[args.RowIndex].DataBoundItem;
                hotkey.active = isChecked;

                ConfigPersistence.SaveHotkeys(Hotkeys);
            };

            dgv_Hotkeys.CellClick += (sender, args) =>
            {
                if (args.RowIndex < 0)
                    return;

                if (args.ColumnIndex == dgv_Hotkeys.Columns["hotkey"]?.Index)
                {
                    var keyEvent = HotkeyPopup.getHotkey();
                    var hotkey = (AbstractHotkeyAction)dgv_Hotkeys.Rows[args.RowIndex].DataBoundItem;
                    updateHotkey(keyEvent, hotkey);
                }
                else if (args.ColumnIndex == dgv_Hotkeys.Columns["remove"]?.Index)
                {
                    var hotkey = (AbstractHotkeyAction)dgv_Hotkeys.Rows[args.RowIndex].DataBoundItem;
                    hotkey.RemoveKeybind();
                    ConfigPersistence.SaveHotkeys(Hotkeys);
                }
                else if (args.ColumnIndex == dgv_Hotkeys.Columns["edit"]?.Index)
                {
                    var hotkey = (AbstractHotkeyAction)dgv_Hotkeys.Rows[args.RowIndex].DataBoundItem;
                    if (string.IsNullOrWhiteSpace(hotkey.attributes))
                        return;

                    if (HotkeyEditor.EditHotkeyAction(hotkey))
                        ConfigPersistence.SaveHotkeys(Hotkeys);
                }
                else
                    return;

                dgv_Hotkeys.Refresh();
            };

            dgv_Hotkeys.CellMouseEnter += (sender, args) =>
            {
                if (args.RowIndex < 0)
                    return;

                var row = dgv_Hotkeys.Rows[args.RowIndex];
                row.Cells[args.ColumnIndex].ToolTipText = ((AbstractHotkeyAction)row.DataBoundItem).tooltip;
            };

            hotkeyBinding = new BindingSource(Hotkeys.hotkeyActions, null);
            dgv_Hotkeys.DataSource = hotkeyBinding;

            DgvFormUtil.AdjustDataGridViewColumns(dgv_Hotkeys);
        }

        private void InitializeAutoActions()
        {
            dgv_AutoActions.RowHeadersVisible = false;
            dgv_AutoActions.AllowUserToAddRows = false;
            dgv_AutoActions.AllowUserToResizeColumns = false;
            dgv_AutoActions.AllowUserToResizeRows = false;
            dgv_AutoActions.DefaultCellStyle.SelectionBackColor = dgv_AutoActions.DefaultCellStyle.BackColor;
            dgv_AutoActions.DefaultCellStyle.SelectionForeColor = dgv_AutoActions.DefaultCellStyle.ForeColor;

            var columns = DgvFormUtil.GetAutoActionsColumns();
            columns.ForEach(column => dgv_AutoActions.Columns.Add(column));

            dgv_AutoActions.CurrentCellDirtyStateChanged += (sender, args) =>
            {
                if (dgv_AutoActions.IsCurrentCellDirty &&
                    dgv_AutoActions.CurrentCell.OwningColumn == dgv_AutoActions.Columns["active"]
                )
                {
                    dgv_AutoActions.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };

            dgv_AutoActions.CellContentClick += (sender, args) =>
            {
                if (args.RowIndex < 0 || args.ColumnIndex != dgv_AutoActions.Columns["active"]?.Index)
                    return;

                var val = (DataGridViewCheckBoxCell)dgv_AutoActions.Rows[args.RowIndex].Cells["active"];
                var isChecked = Convert.ToBoolean(val.Value);

                var autoAction = (AbstractAutoAction)dgv_AutoActions.Rows[args.RowIndex].DataBoundItem;
                autoAction.active = isChecked;

                ConfigPersistence.SaveAutoActions(AutoActions);
            };

            dgv_AutoActions.CellClick += (sender, args) =>
            {
                if (args.RowIndex < 0 || args.ColumnIndex != dgv_Hotkeys.Columns["edit"]?.Index)
                    return;

                var autoAction = (AbstractAutoAction)dgv_AutoActions.Rows[args.RowIndex].DataBoundItem;
                if (string.IsNullOrWhiteSpace(autoAction?.attributes))
                    return;
                if (AutoActionEditor.EditAutoAction(autoAction))
                    ConfigPersistence.SaveAutoActions(AutoActions);

                dgv_AutoActions.Refresh();
            };

            dgv_AutoActions.CellMouseEnter += (sender, args) =>
            {
                if (args.RowIndex < 0)
                    return;

                var row = dgv_AutoActions.Rows[args.RowIndex];
                row.Cells[args.ColumnIndex].ToolTipText = ((AbstractAutoAction)row.DataBoundItem).tooltip;
            };

            autoActionBinding = new BindingSource(AutoActions.autoActions, null);
            dgv_AutoActions.DataSource = autoActionBinding;

            DgvFormUtil.AdjustDataGridViewColumns(dgv_AutoActions);
        }
        
        private void cb_MasterProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_MasterProfile.SelectedItem.ToString() == ADD_NEW_ITEM)
            {     
                AddNewMasterProfile();
                return;
            }
            
            SnoToDefinitionGroups = profileToSkillDefinitionGroups[cb_MasterProfile.SelectedItem.ToString()];
            
            skillsWithDefinitionGroupsDisplayValues = new BindingList<ISnoPower>();
            selectedSkillDefinitionGroupsDisplayValues = new BindingList<DefinitionGroup>();
            
            lb_DefinitionGroupsForSkill.DataSource = selectedSkillDefinitionGroupsDisplayValues;
            
            cb_ShowOnlyForCurrentClass_CheckedChanged(null, null);
        }

        private void AddNewMasterProfile()
        {
            if (!(AddMasterProfile.GetNewMasterProfileName() is string name))
            {
                cb_MasterProfile.SelectedItem = SnoToDefinitionGroups.FirstOrDefault().Value?.configProfileName ?? "Default";
                return;
            }

            if (profileToSkillDefinitionGroups.ContainsKey(name))
            {
                MessageBox.Show($"Profile with the name {name} already exists!");
                cb_MasterProfile_SelectedIndexChanged(null, null);
                return;
            }
            
            profileToSkillDefinitionGroups.Add(name, new Dictionary<uint, DefinitionGroupsForSkill>());
            masterProfileNames = new BindingList<string>(profileToSkillDefinitionGroups.Keys.OrderBy(s => s).Concat(new[] {ADD_NEW_ITEM}).ToList());
            cb_MasterProfile.DataSource = masterProfileNames;
            cb_MasterProfile.SelectedItem = name;
        }

        private void cb_ClassFilterChanged(object sender, EventArgs e)
        {
            cb_Skills.DataSource = HeroClassToSnoPowers[(HeroClass)cb_ClassFilter.SelectedItem];
        }

        private void updateHotkey(HotkeyPopup.MyKeyEvent keyEvent, AbstractHotkeyAction hotkey)
        {
            if (keyEvent is null)
                return;

            var iKeyEvent = keyEvent.toIKeyEvent(Hud.Input);
            hotkey.SetKeyEvent(keyEvent, iKeyEvent);
            ConfigPersistence.SaveHotkeys(Hotkeys);
        }

        private void b_addSkillToDefinitionGroups(object sender, EventArgs e)
        {
            if (!(cb_Skills.SelectedItem is ISnoPower skillToAdd) || SnoToDefinitionGroups.ContainsKey(skillToAdd.Sno))
            {
                MessageBox.Show("Skill has DefinitionGroups already!", "Duplicate skills!", MessageBoxButtons.OK);
                return;
            }

            SnoToDefinitionGroups.Add(
                skillToAdd.Sno,
                new DefinitionGroupsForSkill(snoPowerToHeroClass[skillToAdd.Sno].ToString(), skillToAdd.NameEnglish, cb_MasterProfile.SelectedItem.ToString())
            );
            skillsWithDefinitionGroupsDisplayValues.Add(skillToAdd);

            lb_skillsWithDefinitionGroups.SelectedItem = skillsWithDefinitionGroupsDisplayValues.Last();

            cb_ShowOnlyForCurrentClass_CheckedChanged(sender, e);
        }

        private void b_AddNewDefinitionGroup_Click(object sender, EventArgs e)
        {
            var definitionGroupName = tb_DefintionGroupName.Text;

            if (string.IsNullOrWhiteSpace(definitionGroupName))
                return;

            if (!(lb_skillsWithDefinitionGroups.SelectedItem is ISnoPower currentSnoPower))
            {
                MessageBox.Show("Select a skill first!", "No skill selected!", MessageBoxButtons.OK);
                return;
            }

            var currentSkillDefinitionGroups = SnoToDefinitionGroups[currentSnoPower.Sno];
            if (currentSkillDefinitionGroups.definitionGroups.Any(group => group.name.Equals(definitionGroupName)))
            {
                MessageBox.Show("DefinitionGroup with this name already exists!", "Duplicate name!",
                    MessageBoxButtons.OK);
                return;
            }

            var definitionGroup = new DefinitionGroup(definitionGroupName, currentSnoPower.Sno);
            currentSkillDefinitionGroups.definitionGroups.Add(definitionGroup);

            selectedSkillDefinitionGroupsDisplayValues.ResetBindings();
            tb_DefintionGroupName.Text = "";

            ConfigPersistence.SaveDefinitionGroupsForSkill(currentSkillDefinitionGroups);
        }

        private void lb_skillsWithDefinitionGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!((ISnoPower)lb_skillsWithDefinitionGroups.SelectedItem is ISnoPower currentSnoPower))
            {
                selectedSkillDefinitionGroupsDisplayValues.Clear();
                return;
            }

            var currentlySelectedDefinitionGroups = SnoToDefinitionGroups[currentSnoPower.Sno];

            selectedSkillDefinitionGroupsDisplayValues =
                new BindingList<DefinitionGroup>(currentlySelectedDefinitionGroups.definitionGroups
                );
            lb_DefinitionGroupsForSkill.DataSource = selectedSkillDefinitionGroupsDisplayValues;

            cb_SkillActive.Checked = currentlySelectedDefinitionGroups.active;
        }

        public void cb_ShowOnlyForCurrentClass_CheckedChanged(object sender, EventArgs e)
        {
            var allSnoPowers = SnoToDefinitionGroups
                .Select(pair => Hud.Sno.GetSnoPower(pair.Key))
                .OrderBy(skill => skill.NameEnglish)
                .ToList();
            
            if (cb_ShowOnlyForCurrentClass.Checked)
            {
                var skillsForCurrentClass = HeroClassToSnoPowers[Hud.Game.Me.HeroClassDefinition?.HeroClass ?? HeroClass.None];

                skillsWithDefinitionGroupsDisplayValues = new BindingList<ISnoPower>(
                    allSnoPowers
                        .Where(skill => skillsForCurrentClass.Contains(skill))
                        .OrderBy(skill => skill.NameEnglish)
                        .ToList());
            }
            else
            {
                skillsWithDefinitionGroupsDisplayValues = new BindingList<ISnoPower>(allSnoPowers);
            }

            lb_skillsWithDefinitionGroups.DataSource = skillsWithDefinitionGroupsDisplayValues;
        }

        private void b_DeleteDefinitionGroup_Click(object sender, EventArgs e)
        {
            if (!(lb_DefinitionGroupsForSkill.SelectedItem is DefinitionGroup currentlySelectedDefinitionGroup))
                return;

            var result = Misc.AreYouSureDialogConfirmed("Are you sure you want to delete the DefinitionGroup " +
                                                        currentlySelectedDefinitionGroup.name +
                                                        " and all of it's definitions?");

            if (!result)
                return;
            
            selectedSkillDefinitionGroupsDisplayValues.Remove(currentlySelectedDefinitionGroup);
            var parentDefinitionGroups = SnoToDefinitionGroups[currentlySelectedDefinitionGroup.sno];
            parentDefinitionGroups.definitionGroups.Remove(currentlySelectedDefinitionGroup);
            ConfigPersistence.DeleteDefinitionGroup(parentDefinitionGroups, currentlySelectedDefinitionGroup.name);
        }

        private void b_DeleteSkillFromDefinitionGroups_Click(object sender, EventArgs e)
        {
            if (!(lb_skillsWithDefinitionGroups.SelectedItem is ISnoPower currentlySelectedSkill))
                return;

            var result = Misc.AreYouSureDialogConfirmed(
                "Are you sure you want to delete all DefinitionGroups for skill " +
                currentlySelectedSkill.NameEnglish + "?");

            if (!result) 
                return;

            ConfigPersistence.DeleteSkillDefinitionGroups(SnoToDefinitionGroups[currentlySelectedSkill.Sno]);
            SnoToDefinitionGroups.Remove(currentlySelectedSkill.Sno);
            skillsWithDefinitionGroupsDisplayValues.Remove(currentlySelectedSkill);
        }

        private void cb_DefinitionGroupActive_CheckedChanged(object sender, EventArgs e)
        {
            if (!(lb_DefinitionGroupsForSkill.SelectedItem is DefinitionGroup currentlySelectedDefinitionGroup))
                return;

            currentlySelectedDefinitionGroup.active = cb_DefinitionGroupActive.Checked;
        }

        private void lb_DefinitionGroupsForSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(lb_DefinitionGroupsForSkill.SelectedItem is DefinitionGroup currentlySelectedDefinitionGroup))
                return;

            cb_DefinitionGroupActive.Checked = currentlySelectedDefinitionGroup.active;
        }

        private void cb_SkillActive_CheckedChanged(object sender, EventArgs e)
        {
            if (!(lb_skillsWithDefinitionGroups.SelectedItem is ISnoPower currentlySelectedSnoPower))
                return;

            SnoToDefinitionGroups[currentlySelectedSnoPower.Sno].active = cb_SkillActive.Checked;
        }

        private void b_EditDefinitionGroup_Click(object sender, EventArgs e)
        {
            if (!(lb_DefinitionGroupsForSkill.SelectedItem is DefinitionGroup currentlySelectedDefinitionGroup))
                return;

            var modified = DefinitionGroupEditor.ShowDefinitionGroupEditor(currentlySelectedDefinitionGroup, Hud);
            if (modified)
                ConfigPersistence.SaveDefinitionGroupsForSkill(SnoToDefinitionGroups[currentlySelectedDefinitionGroup.sno]);
        }

        private void lb_DefinitionGroupsForSkill_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            b_EditDefinitionGroup_Click(sender, e);
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigPersistence.SaveDefinitions(SnoToDefinitionGroups);
            ConfigPersistence.SaveKeybinds(Keybinds);
            ConfigPersistence.SaveHotkeys(Hotkeys);
            ConfigPersistence.SaveAutoActions(AutoActions);
            e.Cancel = true;
        }

        private void pb_Donate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.buymeacoffee.com/phelper");
        }
    }
}