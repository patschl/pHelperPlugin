namespace Turbo.plugins.patrick.forms.autoaction
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using autoactions.actions;
    using parameters;
    using Plugins.Patrick.autoactions;
    using Plugins.Patrick.util.winformutil;

    public partial class AutoActionEditor : Form
    {
        private readonly AbstractAutoAction autoAction;

        private List<AbstractParameter> parameters;
        
        private readonly List<Control> addedControls = new List<Control>();

        private bool modified;

        private int yOffset;

        private AutoActionEditor(AbstractAutoAction autoAction)
        {
            InitializeComponent();
            Icon  = Icon.ExtractAssociatedIcon(@"plugins\patrick\resource\icon.ico");

            this.autoAction = autoAction;
            LoadExistingAutoAction();
        }

        public static bool EditAutoAction(AbstractAutoAction autoAction)
        {
            var autoActionEditor = new AutoActionEditor(autoAction) {Text = "AutoActionEditor - " + autoAction.action};
            autoActionEditor.ShowDialog();

            return autoActionEditor.modified;
        }

        private void LoadExistingAutoAction()
        {
            l_AutoActionName.Text = autoAction.action;
            parameters = autoAction.GetParameters();

            GenerateForm();
            
            parameters.ForEach(parameter =>
            {
                var controlForParameter = addedControls.First(control => control.Name.Equals(parameter.propertyName));
                var value = ControlHelper.GetParameterValue(autoAction, parameter.propertyName);
                ControlHelper.ControlTypeToControlSetter[controlForParameter.GetType()](value, controlForParameter);
            });
        }
        
        private void GenerateForm()
        {
            Size = new Size(Size.Width, Size.Height + (parameters.Count * 40));
            b_Save.Location = new Point(b_Save.Location.X, b_Save.Location.Y + (parameters.Count * 40));
            b_Cancel.Location = new Point(b_Cancel.Location.X, b_Cancel.Location.Y + (parameters.Count * 40));

            parameters.ForEach(AddParameterToForm);
        }

        private void AddParameterToForm(AbstractParameter parameter)
        {
            yOffset++;

            var label = ControlHelper.CreateLabel(parameter.propertyName, 1, yOffset);
            Controls.Add(label);
            addedControls.Add(label);

            var inputControl = ControlHelper.CreateParameterInputControl(parameter, 1, yOffset);
            Controls.Add(inputControl);
            addedControls.Add(inputControl);
        }

        private void b_Save_Click(object sender, EventArgs e)
        {
            parameters.ForEach(parameter =>
            {
                var control = addedControls.First(addedControl => addedControl.Name.Equals(parameter.propertyName));
                ControlHelper.ControlTypeToParameterSetter[control.GetType()](parameter, control);
            });

            modified = true;
            
            Close();
        }

        private void b_Cancel_Click(object sender, EventArgs e)
        {
            modified = false;
            Close();
        }
    }
}