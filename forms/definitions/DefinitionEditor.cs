namespace Turbo.plugins.patrick.forms.definitions
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using parameters;
    using Plugins;
    using Plugins.Patrick.util.winformutil;
    using skills;
    using skills.definitions;

    public partial class DefinitionEditor : Form
    {
        private static DefinitionGroup currentDefinitionGroup { get; set; }

        private AbstractDefinition definition;

        private List<AbstractParameter> parameters;

        private readonly IController hud;

        private readonly List<Control> addedControls = new List<Control>();

        private bool modified;

        private int yOffset;

        private DefinitionEditor(IController hud)
        {
            this.hud = hud;
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            Icon = Icon.ExtractAssociatedIcon(@"plugins\patrick\resource\icon.ico");

            cb_DefinitionType.DataSource = AbstractDefinition.DefinitionTypes;
            cb_DefinitionType.DisplayMember = "Name";

            cb_Group.DataSource = Enum.GetValues(typeof(DefinitionType));
        }
        
        private void DefinitionEditor_Load(object sender, EventArgs e)
        {
            if (cb_Group.Enabled)
                return;
            
            parameters.ForEach(parameter =>
            {
                var controlForParameter = addedControls.First(control => control.Name.Equals(parameter.propertyName));
                var value = ControlHelper.GetParameterValue(definition, parameter.propertyName);
                MessageBox.Show("value: " + value);
                ControlHelper.ControlTypeToControlSetter[controlForParameter.GetType()](value, controlForParameter);
            });
        }

        public static AbstractDefinition GetNewDefinition(IController hud, DefinitionGroup parentDefinitionGroup)
        {
            currentDefinitionGroup = parentDefinitionGroup;
            var definitionEditor = GetNewDefinitionEditor(hud);
            definitionEditor.ShowDialog();

            return definitionEditor.definition;
        }

        public static bool EditExistingDefinition(IController hud, AbstractDefinition definition)
        {
            var definitionEditor = GetNewDefinitionEditor(hud, definition);
            definitionEditor.ShowDialog();

            return definitionEditor.modified;
        }

        private static DefinitionEditor GetNewDefinitionEditor(IController hud, AbstractDefinition definition = null)
        {
            
            var definitionEditor = new DefinitionEditor(hud) {Enabled = true};

            if (definition is null)
                return definitionEditor;

            definitionEditor.LoadExistingDefinition(definition);
            definitionEditor.cb_Group.Enabled = false;
            definitionEditor.cb_DefinitionType.Enabled = false;
            
            return definitionEditor;
        }

        private void LoadExistingDefinition(AbstractDefinition existingDefinition)
        {
            currentDefinitionGroup = existingDefinition.definitionGroup;
            cb_Group.SelectedItem = existingDefinition.category;
            cb_DefinitionType.SelectedItem = existingDefinition.GetType();
            definition = existingDefinition;
            
            cb_Inverted.Checked = definition.inverted;
            parameters = definition.GetParameters(hud);

            RegenerateForm();
        }

        private void RegenerateForm()
        {
            ResetForm();
            
            Size = new Size(Size.Width, Size.Height + (parameters.Count * 40));
            b_Save.Location = new Point(b_Save.Location.X, b_Save.Location.Y + (parameters.Count * 40));
            b_Cancel.Location = new Point(b_Cancel.Location.X, b_Cancel.Location.Y + (parameters.Count * 40));

            parameters.ForEach(AddParameterToForm);
        }

        private void AddParameterToForm(AbstractParameter parameter)
        {
            yOffset++;

            var label = ControlHelper.CreateLabel(parameter.propertyName, 2, yOffset);
            Controls.Add(label);
            addedControls.Add(label);

            var inputControl = ControlHelper.CreateParameterInputControl(parameter, 2, yOffset);
            Controls.Add(inputControl);
            addedControls.Add(inputControl);
        }
        
        private void cb_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            var group = (DefinitionType)cb_Group.SelectedItem;
            cb_DefinitionType.DataSource = group == DefinitionType.All 
                ? AbstractDefinition.DefinitionTypes 
                : AbstractDefinition.CategoryToType[group];
        }

        private void cb_DefinitionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            definition = (AbstractDefinition)Activator.CreateInstance((Type)cb_DefinitionType.SelectedItem);
            definition.definitionGroup = currentDefinitionGroup;
            parameters = definition.GetParameters(hud);

            RegenerateForm();
        }
        
        private void b_Save_Click(object sender, EventArgs e)
        {
            parameters.ForEach(parameter =>
            {
                var control = addedControls.First(addedControl => addedControl.Name.Equals(parameter.propertyName));
                ControlHelper.ControlTypeToParameterSetter[control.GetType()](parameter, control);
            });
            definition.inverted = cb_Inverted.Checked;

            modified = true;

            Close();
        }

        private void b_Cancel_Click(object sender, EventArgs e)
        {
            definition = null;
            Close();
        }

        private void ResetForm()
        {
            Size = new Size(500, 215);
            b_Save.Location = new Point(265, 120);
            b_Cancel.Location = new Point(372, 120);

            addedControls.ForEach(control => Controls.Remove(control));
            addedControls.Clear();
            yOffset = 0;
        }
    }
}
