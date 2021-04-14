namespace Turbo.plugins.patrick.util.input
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    using diablo;
    using Plugins;
    using Plugins.Patrick.forms;
    using Plugins.Patrick.util;

    internal static class InputSimulator
    {
        private const uint WM_KEYDOWN = 0x0100;
        private const uint WM_KEYUP = 0x0101;
        private const uint WM_MOUSEMOVE = 0x0200;
        private const uint WM_LBUTTONDOWN = 0x0201;
        private const uint WM_LBUTTONUP = 0x0202;
        private const uint WM_RBUTTONDOWN = 0x0204;
        private const uint WM_RBUTTONUP = 0x0205;
        private const uint WM_MBUTTONDOWN = 0x0207;
        private const uint WM_MBUTTONUP = 0x0208;
        private const uint WM_XBUTTONDOWN = 0x020B;
        private const uint WM_XBUTTONUP = 0x020C;


        
        public static bool PostMessageKeyPress(string key)
        {
            return PressKey(InputUtil.StringToVkCode(key));
        }
        
        public static bool PressKey(Keys key)
        {
            var success = PostMessageKeyDown(key);
            PostMessageKeyUp(key);

            return success;
        }

        public static bool PostMessageKeyDown(string key)
        {
            return PostMessageKeyDown(InputUtil.StringToVkCode(key));
        }

        public static bool PostMessageKeyDown(Keys vkcode)
        {
            if (!IsMouseKey(vkcode))
            {
                return User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_KEYDOWN, (int)vkcode, 0);
            }

            switch (vkcode)
            {
                case Keys.LButton:
                {
                    var currentCursorPositionInGame = GetCurrentCursorPositionInGame();
                    PostMessageKeyDown(Settings.Keybinds[(int)ActionKey.Unknown]);
                    var success = User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_LBUTTONDOWN,
                        User32.MK_LBUTTON,
                        ConvertPositionToLparam(currentCursorPositionInGame.X, currentCursorPositionInGame.Y));
                    PostMessageKeyUp(Settings.Keybinds[(int)ActionKey.Unknown]);
                    return success;
                }
                case Keys.RButton:
                {
                    var currentCursorPositionInGame2 = GetCurrentCursorPositionInGame();
                    return User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_RBUTTONDOWN,
                        User32.MK_RBUTTON,
                        ConvertPositionToLparam(currentCursorPositionInGame2.X, currentCursorPositionInGame2.Y));
                }
                case Keys.MButton:
                {
                    var currentCursorPositionInGame3 = GetCurrentCursorPositionInGame();
                    return User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_MBUTTONDOWN,
                        User32.MK_MBUTTON,
                        ConvertPositionToLparam(currentCursorPositionInGame3.X, currentCursorPositionInGame3.Y));
                }
                case Keys.XButton1:
                {
                    var currentCursorPositionInGame3 = GetCurrentCursorPositionInGame();
                    return User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_XBUTTONDOWN,
                        User32.MK_XBUTTON1,
                        ConvertPositionToLparam(currentCursorPositionInGame3.X, currentCursorPositionInGame3.Y));
                }
                case Keys.XButton2:
                {
                    var currentCursorPositionInGame3 = GetCurrentCursorPositionInGame();
                    return User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_XBUTTONDOWN,
                        User32.MK_XBUTTON2,
                        ConvertPositionToLparam(currentCursorPositionInGame3.X, currentCursorPositionInGame3.Y));
                }
            }

            return false;
        }

        public static void PostMessageKeyUp(string key)
        {
            PostMessageKeyUp(InputUtil.StringToVkCode(key));
        }

        public static void PostMessageKeyUp(Keys vkcode)
        {
            if (!IsMouseKey(vkcode))
            {
                User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_KEYUP, (int)vkcode, 0);
                return;
            }

            switch (vkcode)
            {
                case Keys.LButton:
                {
                    var currentCursorPositionInGame = GetCurrentCursorPositionInGame();
                    User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_LBUTTONUP, 0,
                        ConvertPositionToLparam(currentCursorPositionInGame.X, currentCursorPositionInGame.Y));
                    return;
                }
                case Keys.RButton:
                {
                    var currentCursorPositionInGame2 = GetCurrentCursorPositionInGame();
                    User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_RBUTTONUP, 0,
                        ConvertPositionToLparam(currentCursorPositionInGame2.X, currentCursorPositionInGame2.Y));
                    return;
                }
                case Keys.MButton:
                {
                    var currentCursorPositionInGame3 = GetCurrentCursorPositionInGame();
                    User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_MBUTTONUP, 0,
                        ConvertPositionToLparam(currentCursorPositionInGame3.X, currentCursorPositionInGame3.Y));
                    return;
                }
                case Keys.XButton1:
                case Keys.XButton2:
                {
                    var currentCursorPositionInGame3 = GetCurrentCursorPositionInGame();
                    User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_XBUTTONUP, 0,
                        ConvertPositionToLparam(currentCursorPositionInGame3.X, currentCursorPositionInGame3.Y));
                    return;
                }
            }
        }

        private static bool IsMouseKey(Keys key)
        {
            return key == Keys.LButton || key == Keys.RButton || key == Keys.MButton ||
                   key == Keys.XButton1 || key == Keys.XButton2;
        }

        public static bool PostMessageKeyPress(string key, Point pt)
        {
            return PostMessageKeyPress(key, pt.X, pt.Y);
        }

        public static bool PostMessageKeyPress(string key, int x, int y)
        {
            return PostMessageKeyPress(InputUtil.StringToVkCode(key), x, y);
        }

        public const int CLICK_DELAY_AFTER_MOUSE_MOVE = 15;

        public static bool PostMouseMove( int x, int y)
        {
            var oldMousePos = GetCurrentCursorPositionInGame();
            SetCursorPosition(new Point(x, y));

            return true;
        }

        public static bool PostMessageClickWithMouseMove(string key, int x, int y)
        {
            var oldMousePos = GetCurrentCursorPositionInGame();
            SetCursorPosition(new Point(x, y));

            Thread.Sleep(CLICK_DELAY_AFTER_MOUSE_MOVE);

            var success = PostMessageKeyPress(key, x, y);
            SetCursorPosition(oldMousePos);
            return success;
        }

        public static bool PostMessageKeyPress(Keys vkcode, int x, int y)
        {
            if (!IsMouseKey(vkcode))
            {
                return PostMessageKeyboard(vkcode, x, y);
            }

            switch (vkcode)
            {
                case Keys.LButton:
                {
                    return PostMessageMouseClickLeft(x, y);
                }
                case Keys.RButton:
                {
                    return PostMessageMouseClickRight(x, y);
                }
                case Keys.MButton:
                {
                    return PostMessageMouseClickMiddle(x, y);
                }
            }

            return false;
        }

        public static bool IsKeyPressed(string key)
        {
            return GetAsyncKeyState(InputUtil.StringToVkCode(key)) != 0;
        }

        public static void PostMessageMouseClickRight()
        {
            PostMessageMouseClickRight(GetCurrentCursorPositionInGame());
        }

        public static void PostMessageMouseClickLeft()
        {
            PostMessageMouseClickLeft(GetCurrentCursorPositionInGame());
        }

        public static void PostMessageMouseClickRight(Point coords)
        {
            PostMessageMouseClickRight(coords.X, coords.Y);
        }

        public static void PostMessageMouseClickLeft(Point coords)
        {
            PostMessageMouseClickLeft(coords.X, coords.Y);
        }


        private static bool PostMessageMouseClickLeft(int x, int y)
        {
            var lParam = ConvertPositionToLparam(x, y);
            var success = User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_LBUTTONDOWN,
                User32.MK_LBUTTON, lParam);
            User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_LBUTTONUP, 0, lParam);
            return success;
        }

        private static bool PostMessageMouseClickRight(int x, int y)
        {
            var lParam = ConvertPositionToLparam(x, y);
            var success = User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_RBUTTONDOWN,
                User32.MK_RBUTTON, lParam);
            User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_RBUTTONUP, 0, lParam);
            return success;
        }

        private static bool PostMessageMouseClickMiddle(int x, int y)
        {
            var lParam = ConvertPositionToLparam(x, y);
            var success = User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_MBUTTONDOWN,
                User32.MK_MBUTTON, lParam);
            User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_MBUTTONUP, 0, lParam);
            return success;
        }

        public static bool PostMessageKeyboard(Keys vkcode, int x, int y)
        {
            var lParam = ConvertPositionToLparam(x, y);
            User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_MOUSEMOVE, 0, lParam);
            var success = User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_KEYDOWN, (int)vkcode,
                lParam);
            User32.PostMessage(D3Client.GetHandle().MainWindowHandle, WM_KEYUP, (int)vkcode, lParam);
            return success;
        }

        private static void SetCursorPosition(Point pt)
        {
            Cursor.Position = pt;
        }


        private static Point GetCurrentCursorPositionInGame()
        {
            var x = Cursor.Position.X;
            var y = Cursor.Position.Y;
            return new Point(x, y);
        }


        private static int ConvertPositionToLparam(int x, int y)
        {
            return (y << 16) | (x & 65535);
        }

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        const int KEY_DOWN_EVENT = 0x1; //Key down flag
        const int KEY_UP_EVENT = 0x2; //Key up flag

        public static void HoldKeyDown(byte key)
        {
            keybd_event(key, 0, 0, 0);
        }

        public static void ReleaseKey(byte key)
        {
            keybd_event(key, 0, KEY_UP_EVENT, 0);
        }

        private static class User32
        {
            [DllImport("user32.dll")]
            public static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

            [DllImport("user32.dll")]
            public static extern bool SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

            public static int MK_SHIFT = 0x10;

            public static int MK_CONTROL = 0x11;

            public static int MK_LBUTTON = 0x01;

            public static int MK_MBUTTON = 0x04;

            public static int MK_RBUTTON = 0x02;

            public static int MK_XBUTTON1 = 0x05;

            public static int MK_XBUTTON2 = 0x06;
        }
    }
}