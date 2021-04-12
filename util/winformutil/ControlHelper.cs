namespace Turbo.Plugins.Patrick.util.winformutil
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using plugins.patrick.parameters;
    using plugins.patrick.parameters.types;

    public static class ControlHelper
    {
        private static readonly Dictionary<Type, Func<AbstractParameter, int, int, Control>> SimpleParameterTypeToUiGenerator =
            new Dictionary<Type, Func<AbstractParameter, int, int, Control>>
            {
                {typeof(int), (param, itemsAbove, offset) => CreateNumericUiControl(param as SimpleParameter<int>, itemsAbove, offset)},
                {
                    typeof(string),
                    (param, itemsAbove, offset) => CreateStringUiControl(param as SimpleParameter<string>, itemsAbove, offset)
                },
                {typeof(bool), (param, itemsAbove, offset) => CreateBoolUiControl(param as SimpleParameter<bool>, itemsAbove, offset)}
            };

        public static readonly Dictionary<Type, Action<AbstractParameter, Control>> ControlTypeToParameterSetter =
            new Dictionary<Type, Action<AbstractParameter, Control>>
            {
                {
                    typeof(NumericUpDown), (param, control) => SetNumericProperty(param as SimpleParameter<int>, control as NumericUpDown)
                },
                {typeof(TextBox), (param, control) => SetStringProperty(param as SimpleParameter<string>, control as TextBox)},
                {typeof(CheckBox), (param, control) => SetCheckboxProperty(param as SimpleParameter<bool>, control as CheckBox)},
                {typeof(ComboBox), (param, control) => SetComboboxProperty(param as ContextParameter, control as ComboBox)}
            };

        public static readonly Dictionary<Type, Action<object, Control>> ControlTypeToControlSetter =
            new Dictionary<Type, Action<object, Control>>
            {
                {typeof(NumericUpDown), (param, control) => SetNumericControlValue(Convert.ToDecimal(param), control as NumericUpDown)},
                {typeof(TextBox), (param, control) => SetStringControlValue(param as string, control as TextBox)},
                {typeof(CheckBox), (param, control) => SetCheckboxControlValue((bool)param, control as CheckBox)},
                {typeof(ComboBox), (param, control) => SetComboboxControlValue(param, control as ComboBox)}
            };

        public static Control CreateLabel(string parameterPropertyName, int itemsAbove, int yOffset)
        {
            return new Label
            {
                Enabled = true,
                Size = new Size(150, 20),
                Location = new Point(12, (40 * itemsAbove) + (40 * yOffset)),
                Name = "l_" + parameterPropertyName,
                Text = parameterPropertyName,
                Font = new Font(FontFamily.GenericSansSerif, 10)
            };
        }

        public static Control CreateParameterInputControl(AbstractParameter parameter, int itemsAbove, int yOffset)
        {
            switch (parameter.parameterType)
            {
                case ParameterType.Simple:
                    return CreateSimpleParameterInputControl(parameter, itemsAbove, yOffset);
                case ParameterType.ContextParameter:
                    return CreateComboboxUiControl(parameter as ContextParameter, itemsAbove, yOffset);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static Control CreateSimpleParameterInputControl(AbstractParameter simpleParameter, int itemsAbove, int yOffset)
        {
            return SimpleParameterTypeToUiGenerator[simpleParameter.templateType](simpleParameter, itemsAbove, yOffset);
        }

        private static Control CreateNumericUiControl(SimpleParameter<int> simpleParameter, int itemsAbove, int yOffset)
        {
            var numericUpDown = new NumericUpDown
            {
                Enabled = true,
                Size = new Size(119, 20),
                Location = new Point(203, (40 * itemsAbove) + (40 * yOffset)),
                Name = simpleParameter.propertyName,
                Font = new Font(FontFamily.GenericSansSerif, 10),
                Maximum = decimal.MaxValue,
                Value = Convert.ToDecimal(simpleParameter.defaultValue)
            };
            numericUpDown.Controls.RemoveAt(0);
            numericUpDown.Width -= 4;

            return numericUpDown;
        }

        private static Control CreateStringUiControl(SimpleParameter<string> simpleParameter, int itemsAbove, int yOffset)
        {
            return new TextBox
            {
                Enabled = true,
                Text = simpleParameter.defaultValue,
                Size = new Size(115, 20),
                Location = new Point(203, (40 * itemsAbove) + (40 * yOffset)),
                Name = simpleParameter.propertyName,
                Font = new Font(FontFamily.GenericSansSerif, 10),
            };
        }

        private static Control CreateBoolUiControl(SimpleParameter<bool> simpleParameter, int itemsAbove, int yOffset)
        {
            return new CheckBox
            {
                Enabled = true,
                Location = new Point(203, (40 * itemsAbove) + (40 * yOffset)),
                Name = simpleParameter.propertyName,
                Checked = simpleParameter.defaultValue
            };
        }

        private static Control CreateComboboxUiControl(ContextParameter contextParameter, int itemsAbove, int yOffset)
        {
            return new ComboBox
            {
                Enabled = true,
                Size = new Size(190, 20),
                Location = new Point(163, (40 * itemsAbove) + (40 * yOffset)),
                Name = contextParameter.propertyName,
                Font = new Font(FontFamily.GenericSansSerif, 10),
                DataSource = contextParameter.options,
                DisplayMember = contextParameter.displayMember,
                AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                AutoCompleteSource = AutoCompleteSource.ListItems,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
        }

        private static void SetNumericProperty(SimpleParameter<int> parameter, NumericUpDown control)
        {
            parameter.setter((int)control.Value);
        }

        private static void SetStringProperty(SimpleParameter<string> parameter, TextBox control)
        {
            parameter.setter(control.Text);
        }

        private static void SetCheckboxProperty(SimpleParameter<bool> parameter, CheckBox control)
        {
            parameter.setter(control.Checked);
        }

        private static void SetComboboxProperty(ContextParameter parameter, ComboBox control)
        {
            parameter.setter(control.SelectedItem);
        }

        private static void SetNumericControlValue(decimal value, NumericUpDown control)
        {
            control.Value = value;
        }

        private static void SetStringControlValue(string value, TextBox control)
        {
            control.Text = value;
        }

        private static void SetCheckboxControlValue(bool value, CheckBox control)
        {
            control.Checked = value;
        }

        private static void SetComboboxControlValue(object value, ComboBox control)
        {
            control.SelectedItem = value;
        }

        public static object GetParameterValue(object definition, string parameterName)
        {
            var propertyInfo = definition.GetType().GetProperty(parameterName);
            if (propertyInfo is null)
                return parameterName + " was null";

            return propertyInfo.GetValue(definition, null);
        }
    }
}