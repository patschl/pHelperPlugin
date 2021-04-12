namespace Turbo.plugins.patrick.forms.hotkeys
{
    using System.Windows.Forms;
    using Plugins;
    using util.input;

    public partial class HotkeyPopup : Form
    {
        private MyKeyEvent keyEvent;

        private HotkeyPopup()
        {
            keyEvent = new MyKeyEvent();
            InitializeComponent();
        }

        public static MyKeyEvent getHotkey()
        {
            var hotkeyPopup = new HotkeyPopup();
            hotkeyPopup.ShowDialog();

            return hotkeyPopup.keyEvent;
        }

        private void KeypressPopup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.Menu || e.KeyCode == Keys.ShiftKey)
            {
                return;
            }

            if (e.KeyCode == Keys.Escape)
            {
                keyEvent = null;
            }
            else
            {
                keyEvent.AltPressed = e.Modifiers.ToString().Contains("Alt");
                keyEvent.ControlPressed = e.Modifiers.ToString().Contains("Control");
                keyEvent.ShiftPressed = e.Modifiers.ToString().Contains("Shift");
                keyEvent.Key = e.KeyCode;
            }

            Close();
        }

        public class MyKeyEvent
        {
            public Keys Key { get; set; }

            public bool ControlPressed { get; set; }

            public bool AltPressed { get; set; }

            public bool ShiftPressed { get; set; }

            public MyKeyEvent()
            {
            }

            public MyKeyEvent(Keys key, bool controlPressed, bool altPressed, bool shiftPressed)
            {
                Key = key;
                ControlPressed = controlPressed;
                AltPressed = altPressed;
                ShiftPressed = shiftPressed;
            }

            public IKeyEvent toIKeyEvent(IInputController inputController)
            {
                return inputController.CreateKeyEvent(
                    true,
                    InputUtil.KeysToKey(Key),
                    ControlPressed,
                    AltPressed,
                    ShiftPressed);
            }

            public override string ToString()
            {
                var result = ControlPressed ? "Control + " : "";
                result += AltPressed ? "Alt + " : "";
                result += ShiftPressed ? "Shift + " : "";
                result += Key;
                return result;
            }

            protected bool Equals(MyKeyEvent other)
            {
                return Key == other.Key && ControlPressed == other.ControlPressed && AltPressed == other.AltPressed &&
                       ShiftPressed == other.ShiftPressed;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((MyKeyEvent)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = (int)Key;
                    hashCode = (hashCode * 397) ^ ControlPressed.GetHashCode();
                    hashCode = (hashCode * 397) ^ AltPressed.GetHashCode();
                    hashCode = (hashCode * 397) ^ ShiftPressed.GetHashCode();
                    return hashCode;
                }
            }
        }
    }
}