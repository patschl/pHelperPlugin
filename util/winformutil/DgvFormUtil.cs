namespace Turbo.plugins.patrick.util.winformutil
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    public static class DgvFormUtil
    {
        public static void AdjustDataGridViewColumns(DataGridView dataGridView)
        {
            var activeColumn = dataGridView.Columns["active"];
            if (activeColumn != null)
            {
                activeColumn.Width = 45;
                activeColumn.HeaderText = "Active";
                activeColumn.DisplayIndex = 0;
            }

            var actionColumn = dataGridView.Columns["action"];
            if (actionColumn != null)
            {
                actionColumn.Width = 150;
                actionColumn.HeaderText = "Action";
                actionColumn.DisplayIndex = 1;
            }

            var attributeColumn = dataGridView.Columns["attributes"];
            if (attributeColumn == null) 
                return;
                
            attributeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            attributeColumn.HeaderText = "Additional attributes";
            attributeColumn.DisplayIndex = 2;
        }
        
        public static List<DataGridViewColumn> GetDefinitionGroupEditorColumns()
        {
            var activeColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Active",
                Name = "active",
                Visible = true,
                Width = 45,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            var invertedColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Inverted",
                Name = "inverted",
                Visible = true,
                Width = 60,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            var definitionTypeColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Definition Type",
                Name = "definition",
                Visible = true,
                Width = 180,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            var definitionAttributesColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Definition Attributes",
                Name = "attributes",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            var editButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "edit",
                Visible = true,
                Width = 35,
                Text = "Edit",
                ReadOnly = true,
                UseColumnTextForButtonValue = true,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                ToolTipText = "Edit definition"
            };
            var removeButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "delete",
                Visible = true,
                Width = 35,
                Text = "X",
                ReadOnly = true,
                UseColumnTextForButtonValue = true,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                ToolTipText = "Delete definition"
            };
            
            return new List<DataGridViewColumn>
            {
                activeColumn,
                invertedColumn,
                definitionTypeColumn,
                definitionAttributesColumn,
                editButtonColumn,
                removeButtonColumn
            };
        }

        public static List<DataGridViewColumn> GetHotkeysColumns()
        {
            var editHotkeyButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Hotkey",
                Name = "hotkey",
                DataPropertyName = "hotkey",
                Visible = true,
                Width = 140,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                ToolTipText = "Edit keybind"
            };
            var editHokeyAttributesButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "edit",
                Visible = true,
                Width = 35,
                Text = "Edit",
                ReadOnly = true,
                UseColumnTextForButtonValue = true,
                DisplayIndex = 5,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            var removeHotkeyButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "remove",
                Visible = true,
                Width = 35,
                Text = "X",
                ReadOnly = true,
                UseColumnTextForButtonValue = true,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                ToolTipText = "Remove keybind"
            };
            
            return new List<DataGridViewColumn>
            {
                editHotkeyButtonColumn,
                editHokeyAttributesButtonColumn,
                removeHotkeyButtonColumn
            };
        }

        public static List<DataGridViewColumn> GetAutoActionsColumns()
        {
            var editAutoActionButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "edit",
                Visible = true,
                Width = 35,
                Text = "Edit",
                ReadOnly = true,
                UseColumnTextForButtonValue = true,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                ToolTipText = "Edit auto action"
            };
            
            return new List<DataGridViewColumn>
            {
                editAutoActionButtonColumn
            };
        }
    }
}