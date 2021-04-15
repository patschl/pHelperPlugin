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
            InputSimulator.PostMessageMouseClickLeft(uiElement.Rectangle.GetCenter());
        }

        public static void RightClick(this IUiElement uiElement)
        {
            InputSimulator.PostMessageMouseClickRight(uiElement.Rectangle.GetCenter());
        }

        public static void Click(this IItem item)
        {
            var offsetFloorCoordinate = item.FloorCoordinate.Offset(0, 0, (item.RadiusScaled * 3));
            var offsetScreenCoordinate = offsetFloorCoordinate.ToScreenCoordinate();
            var point = new Point((int)offsetScreenCoordinate.X, (int)offsetScreenCoordinate.Y);
            InputSimulator.PostMessageMouseClickLeft(point);
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