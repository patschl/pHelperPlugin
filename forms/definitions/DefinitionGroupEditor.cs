namespace Turbo.plugins.patrick.forms.definitions
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Plugins;
    using skills;
    using util.winformutil;

    public partial class DefinitionGroupEditor : Form
    {
        private static DefinitionGroupEditor Instance;

        private DefinitionGroup parentDefinitionGroup;

        private bool modified;

        private IController hud;

        private DefinitionGroupEditor(IController hud)
        {
            this.hud = hud;
            InitializeComponent();
            InitializeDataGridView();
            Icon = Icon.ExtractAssociatedIcon(@"plugins\patrick\resource\icon.ico");
        }

        public static bool ShowDefinitionGroupEditor(DefinitionGroup definitionGroup, IController hud)
        {
            if (Instance == null || Instance.IsDisposed)
            {
                Instance = new DefinitionGroupEditor(hud);
            }

            Instance.Text = "Definition Group Editor - " + definitionGroup.name;
            Instance.ShowEditor(definitionGroup);

            return Instance.modified;
        }

        private void ShowEditor(DefinitionGroup definitionGroup)
        {
            parentDefinitionGroup = definitionGroup;
            modified = false;
            ShowDialog();
        }

        private void EditDefinitionGroup_Load(object sender, EventArgs e)
        {
            ReloadDefinitions();
        }

        private void b_AddDefinition_Click(object sender, EventArgs e)
        {
            var definition = DefinitionEditor.GetNewDefinition(hud, parentDefinitionGroup);

            if (definition is null)
                return;

            definition.SetParentDefinitionGroup(parentDefinitionGroup);
            parentDefinitionGroup.definitions.Add(definition);
            modified = true;

            ReloadDefinitions();
        }

        private void DefinitionGroupEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
                return;

            e.Cancel = true;
            dgv_Definitions.Rows.Clear();
            Hide();
        }

        private void b_Close_Click(object sender, EventArgs e)
        {
            dgv_Definitions.Rows.Clear();
            Hide();
        }

        private void ReloadDefinitions()
        {
            dgv_Definitions.Rows.Clear();

            parentDefinitionGroup.definitions.ForEach(definition =>
                {
                    var index = dgv_Definitions.Rows.Add(definition.active, definition.inverted, definition.name, definition.attributes);
                    dgv_Definitions.Rows[index].Cells[2].ToolTipText = definition.tooltip;
                    dgv_Definitions.Rows[index].Cells[3].ToolTipText = definition.tooltip;
                }
            );
        }

        private void  InitializeDataGridView()
        {
            dgv_Definitions.RowHeadersVisible = false;
            dgv_Definitions.AllowUserToAddRows = false;
            dgv_Definitions.AllowUserToResizeColumns = false;
            dgv_Definitions.AllowUserToResizeRows = false;
            dgv_Definitions.DefaultCellStyle.SelectionBackColor = dgv_Definitions.DefaultCellStyle.BackColor;
            dgv_Definitions.DefaultCellStyle.SelectionForeColor = dgv_Definitions.DefaultCellStyle.ForeColor;

            var columns = DgvFormUtil.GetDefinitionGroupEditorColumns();
            columns.ForEach(column => dgv_Definitions.Columns.Add(column));

            dgv_Definitions.CurrentCellDirtyStateChanged += (sender, args) =>
            {
                if (dgv_Definitions.IsCurrentCellDirty &&
                    (dgv_Definitions.CurrentCell.OwningColumn == dgv_Definitions.Columns["active"] ||
                     dgv_Definitions.CurrentCell.OwningColumn == dgv_Definitions.Columns["inverted"])
                )
                {
                    dgv_Definitions.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };

            dgv_Definitions.CellContentClick += (sender, args) =>
            {
                if (args.ColumnIndex == dgv_Definitions.Columns["active"]?.Index)
                {
                    var val = (DataGridViewCheckBoxCell)dgv_Definitions.Rows[args.RowIndex].Cells["active"];
                    var isChecked = Convert.ToBoolean(val.Value);
                    parentDefinitionGroup.definitions[args.RowIndex].active = isChecked;
                    modified = true;
                }

                else if (args.ColumnIndex == dgv_Definitions.Columns["inverted"]?.Index)
                {
                    var val = (DataGridViewCheckBoxCell)dgv_Definitions.Rows[args.RowIndex].Cells["inverted"];
                    var isChecked = Convert.ToBoolean(val.Value);
                    parentDefinitionGroup.definitions[args.RowIndex].inverted = isChecked;
                    modified = true;
                }
            };

            dgv_Definitions.CellClick += (sender, args) =>
            {
                if (args.ColumnIndex == dgv_Definitions.Columns["edit"]?.Index)
                    modified |= DefinitionEditor.EditExistingDefinition(hud, parentDefinitionGroup.definitions[args.RowIndex]);

                else if (args.ColumnIndex == dgv_Definitions.Columns["delete"]?.Index)
                {
                    parentDefinitionGroup.definitions.RemoveAt(args.RowIndex);
                    modified = true;
                }

                if (modified)
                    ReloadDefinitions();
            };
        }
    }
}