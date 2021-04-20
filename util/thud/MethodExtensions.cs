namespace Turbo.plugins.patrick.util.thud
{
    using System.Drawing;
    using input;
    using Plugins.Patrick.forms;
    using Plugins.Patrick.util;
    using Plugins;

    public static class MethodExtensions
    {
        public static void Click(this IUiElement uiElement)
        {
            uiElement.Rectangle.Click();
        }

        public static void RightClick(this IUiElement uiElement)
        {
            uiElement.Rectangle.RightClick();
        }

        public static void Click(this RectangleF rectangleF)
        {
            InputSimulator.PostMessageMouseClickLeft(rectangleF.GetCenter());
        }

        public static void RightClick(this RectangleF rectangleF)
        {
            InputSimulator.PostMessageMouseClickRight(rectangleF.GetCenter());
        }

        public static void Click(this IItem item)
        {
            InputSimulator.PostMessageMouseClickLeft((int)item.FloorCoordinate.ToScreenCoordinate().X, (int)item.FloorCoordinate.ToScreenCoordinate().Y);
        }

        public static void Cast(this IPlayerSkill skill)
        {
            InputSimulator.PressKey(Settings.Keybinds[(int)skill.Key]);
        }

        public static bool CursorInsideRect(this IWindow window, RectangleF rectangle)
        {
            return window.CursorInsideRect(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        private static Point GetCenter(this RectangleF rectangleF)
        {
            return new Point(
                (int)(rectangleF.X + (rectangleF.Width / 2)),
                (int)(rectangleF.Y + (rectangleF.Height / 2))
            );
        }
    }
}
