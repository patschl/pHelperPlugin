namespace Turbo.plugins.patrick.util.input
{
    using System.Collections.Generic;
    using System.Windows.Forms;
    using SharpDX.DirectInput;

    public static class InputUtil
    {
        
        public static Keys StringToVkCode(string input)
        {
            switch (input)
            {
                case "LMB":
                    return Keys.LButton;
                case "RMB":
                    return Keys.RButton;
                case "MMB":
                    return Keys.MButton;
                case "XBUTTON1":
                case "MOUSE4":
                    return Keys.XButton1;
                case "XBUTTON2":
                case "MOUSE5":
                    return Keys.XButton2;
                case "0":
                case "D0":
                    return Keys.D0;
                case "1":
                case "D1":
                    return Keys.D1;
                case "2":
                case "D2":
                    return Keys.D2;
                case "3":
                case "D3":
                    return Keys.D3;
                case "4":
                case "D4":
                    return Keys.D4;
                case "5":
                case "D5":
                    return Keys.D5;
                case "6":
                case "D6":
                    return Keys.D6;
                case "7":
                case "D7":
                    return Keys.D7;
                case "8":
                case "D8":
                    return Keys.D8;
                case "9":
                case "D9":
                    return Keys.D9;
                case "A":
                    return Keys.A;
                case "B":
                    return Keys.B;
                case "C":
                    return Keys.C;
                case "D":
                    return Keys.D;
                case "E":
                    return Keys.E;
                case "F":
                    return Keys.F;
                case "G":
                    return Keys.G;
                case "H":
                    return Keys.H;
                case "I":
                    return Keys.I;
                case "J":
                    return Keys.J;
                case "K":
                    return Keys.K;
                case "L":
                    return Keys.L;
                case "M":
                    return Keys.M;
                case "N":
                    return Keys.N;
                case "O":
                    return Keys.O;
                case "P":
                    return Keys.P;
                case "Q":
                    return Keys.Q;
                case "R":
                    return Keys.R;
                case "S":
                    return Keys.S;
                case "T":
                    return Keys.T;
                case "U":
                    return Keys.U;
                case "V":
                    return Keys.V;
                case "W":
                    return Keys.W;
                case "X":
                    return Keys.X;
                case "Y":
                    return Keys.Y;
                case "Z":
                    return Keys.Z;
                case "ESC":
                    return Keys.Escape;
                case "SHIFT":
                    return Keys.ShiftKey;
                case "CONTROL":
                    return Keys.ControlKey;
                case "ALT":
                    return Keys.Menu;
                case "SPACE":
                    return Keys.Space;
                case "ENTER":
                case "RETURN":
                    return Keys.Return;
                case "TAB":
                    return Keys.Tab;
                case "F1":
                    return Keys.F1;
                case "F2":
                    return Keys.F2;
                case "F3":
                    return Keys.F3;
                case "F4":
                    return Keys.F4;
                case "F5":
                    return Keys.F5;
                case "F6":
                    return Keys.F6;
                case "F7":
                    return Keys.F7;
                case "F8":
                    return Keys.F8;
                case "F9":
                    return Keys.F9;
                case "F10":
                    return Keys.F10;
                case "F11":
                    return Keys.F11;
                case "F12":
                    return Keys.F12;
                case "HOME":
                    return Keys.Home;
                case "END":
                    return Keys.End;
                case "DELETE":
                    return Keys.Delete;
                case "NumPad0":
                    return Keys.NumPad0;
                case "NumPad1":
                    return Keys.NumPad1;
                case "NumPad2":
                    return Keys.NumPad2;
                case "NumPad3":
                    return Keys.NumPad3;
                case "NumPad4":
                    return Keys.NumPad4;
                case "NumPad5":
                    return Keys.NumPad5;
                case "NumPad6":
                    return Keys.NumPad6;
                case "NumPad7":
                    return Keys.NumPad7;
                case "NumPad8":
                    return Keys.NumPad8;
                case "NumPad9":
                    return Keys.NumPad9;
            }

            return 0;
        }

        public static Key KeysToKey(Keys input)
        {
            switch (input)
            {
                case Keys.D0:
                    return Key.D0;
                case Keys.D1:
                    return Key.D1;
                case Keys.D2:
                    return Key.D2;
                case Keys.D3:
                    return Key.D3;
                case Keys.D4:
                    return Key.D4;
                case Keys.D5:
                    return Key.D5;
                case Keys.D6:
                    return Key.D6;
                case Keys.D7:
                    return Key.D7;
                case Keys.D8:
                    return Key.D8;
                case Keys.D9:
                    return Key.D9;
                case Keys.A:
                    return Key.A;
                case Keys.B:
                    return Key.B;
                case Keys.C:
                    return Key.C;
                case Keys.D:
                    return Key.D;
                case Keys.E:
                    return Key.E;
                case Keys.F:
                    return Key.F;
                case Keys.G:
                    return Key.G;
                case Keys.H:
                    return Key.H;
                case Keys.I:
                    return Key.I;
                case Keys.J:
                    return Key.J;
                case Keys.K:
                    return Key.K;
                case Keys.L:
                    return Key.L;
                case Keys.M:
                    return Key.M;
                case Keys.N:
                    return Key.N;
                case Keys.O:
                    return Key.O;
                case Keys.P:
                    return Key.P;
                case Keys.Q:
                    return Key.Q;
                case Keys.R:
                    return Key.R;
                case Keys.S:
                    return Key.S;
                case Keys.T:
                    return Key.T;
                case Keys.U:
                    return Key.U;
                case Keys.V:
                    return Key.V;
                case Keys.W:
                    return Key.W;
                case Keys.X:
                    return Key.X;
                case Keys.Y:
                    return Key.Y;
                case Keys.Z:
                    return Key.Z;
                case Keys.Escape:
                    return Key.Escape;
                case Keys.Shift:
                case Keys.ShiftKey:
                case Keys.LShiftKey:
                case Keys.RShiftKey:
                    return Key.LeftShift;
                case Keys.Control:
                case Keys.ControlKey:
                case Keys.LControlKey:
                case Keys.RControlKey:
                    return Key.LeftControl;
                case Keys.Menu:
                case Keys.LMenu:
                case Keys.RMenu:
                case Keys.Alt:
                    return Key.LeftAlt;
                case Keys.Space:
                    return Key.Space;
                case Keys.Return:
                    return Key.Return;
                case Keys.Tab:
                    return Key.Tab;
                case Keys.F1:
                    return Key.F1;
                case Keys.F2:
                    return Key.F2;
                case Keys.F3:
                    return Key.F3;
                case Keys.F4:
                    return Key.F4;
                case Keys.F5:
                    return Key.F5;
                case Keys.F6:
                    return Key.F6;
                case Keys.F7:
                    return Key.F7;
                case Keys.F8:
                    return Key.F8;
                case Keys.F9:
                    return Key.F9;
                case Keys.F10:
                    return Key.F10;
                case Keys.F11:
                    return Key.F11;
                case Keys.F12:
                    return Key.F12;
                case Keys.Home:
                    return Key.Home;
                case Keys.End:
                    return Key.End;
                case Keys.Delete:
                    return Key.Delete;
                case Keys.NumPad0:
                    return Key.NumberPad0;
                case Keys.NumPad1:
                    return Key.NumberPad1;
                case Keys.NumPad2:
                    return Key.NumberPad2;
                case Keys.NumPad3:
                    return Key.NumberPad3;
                case Keys.NumPad4:
                    return Key.NumberPad4;
                case Keys.NumPad5:
                    return Key.NumberPad5;
                case Keys.NumPad6:
                    return Key.NumberPad6;
                case Keys.NumPad7:
                    return Key.NumberPad7;
                case Keys.NumPad8:
                    return Key.NumberPad8;
                case Keys.NumPad9:
                    return Key.NumberPad9;
            }

            return 0;
        }

        public static List<Keys> KeyboardKeys()
        {
            return new List<Keys>
            {
                Keys.D0,
                Keys.D1,
                Keys.D2,
                Keys.D3,
                Keys.D4,
                Keys.D5,
                Keys.D6,
                Keys.D7,
                Keys.D8,
                Keys.D9,
                Keys.A,
                Keys.B,
                Keys.C,
                Keys.D,
                Keys.E,
                Keys.F,
                Keys.G,
                Keys.H,
                Keys.I,
                Keys.J,
                Keys.K,
                Keys.L,
                Keys.M,
                Keys.N,
                Keys.O,
                Keys.P,
                Keys.Q,
                Keys.R,
                Keys.S,
                Keys.T,
                Keys.U,
                Keys.V,
                Keys.W,
                Keys.X,
                Keys.Y,
                Keys.Z,
                Keys.Escape,
                Keys.ShiftKey,
                Keys.ControlKey,
                Keys.Menu,
                Keys.Alt,
                Keys.Space,
                Keys.Return,
                Keys.Tab,
                Keys.F1,
                Keys.F2,
                Keys.F3,
                Keys.F4,
                Keys.F5,
                Keys.F6,
                Keys.F7,
                Keys.F8,
                Keys.F9,
                Keys.F10,
                Keys.F11,
                Keys.F12,
                Keys.Home,
                Keys.End,
                Keys.Delete,
                Keys.NumPad0,
                Keys.NumPad1,
                Keys.NumPad2,
                Keys.NumPad3,
                Keys.NumPad4,
                Keys.NumPad5,
                Keys.NumPad6,
                Keys.NumPad7,
                Keys.NumPad8,
                Keys.NumPad9,
            };
        }

        public static List<Keys> MouseKeys()
        {
            return new List<Keys>
            {
                Keys.LButton,
                Keys.RButton,
                Keys.XButton1,
                Keys.XButton2,
                Keys.MButton
            };
        }
    }
}