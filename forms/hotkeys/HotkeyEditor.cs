namespace Turbo.plugins.patrick.forms.hotkeys
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using parameters;
    using patrick.hotkeys.actions;
    using Plugins.Patrick.util.winformutil;

    public partial class HotkeyEditor : Form
    {
        private readonly AbstractHotkeyAction hotkey;

        private List<AbstractParameter> parameters;

        private readonly List<Control> addedControls = new List<Control>();

        private bool modified;

        private int yOffset;

        private HotkeyEditor(AbstractHotkeyAction hotkey)
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(@"plugins\patrick\resource\icon.ico");

            this.hotkey = hotkey;
            LoadExistingHotkey();
        }

        public static bool EditHotkeyAction(AbstractHotkeyAction hotkey)
        {
            var hotkeyEditor = new HotkeyEditor(hotkey) {Text = "HotkeyEditor - " + hotkey.action};
            hotkeyEditor.ShowDialog();

            return hotkeyEditor.modified;
        }

        private void LoadExistingHotkey()
        {
            l_HotkeyName.Text = hotkey.action;
            parameters = hotkey.GetParameters();

            GenerateForm();

            parameters.ForEach(parameter =>
            {
                var controlForParameter = addedControls.First(control => control.Name.Equals(parameter.propertyName));
                var value = ControlHelper.GetParameterValue(hotkey, parameter.propertyName);
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