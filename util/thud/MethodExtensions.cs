namespace Turbo.plugins.patrick.util.thud
{
    using System.Drawing;
    using input;
    using Plugins;
    using Plugins.Patrick.forms;
    using Plugins.Patrick.util;

    public static class MethodExtensions
    {
        public static void Click(this IUiElement uiElement)
        {
            InputSimulator.PostMessageMouseClickLeft(uiElement.Rectangle.GetCenter());
        }

        public static void Cast(this IPlayerSkill skill)
        {
            InputSimulator.PressKey(Settings.Keybinds[(int)skill.Key]);
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