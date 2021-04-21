namespace Turbo.plugins.patrick.util.thud
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using diablo;
    using executors;
    using input;
    using logger;
    using Plugins;
    using Plugins.Patrick.forms;

    public static class RenderControllerFunctions
    {
        public static void WaitForVisiblityAndRightClickOrAbortHotkeyEvent(this IRenderController renderController, string path,
            int maxWaitTimeMs = 2000, int intervalMs = 25)
        {
            WaitForVisiblityAndClickOrAbortHotkeyEvent(renderController, path, maxWaitTimeMs, intervalMs, false);
        }

        public static void WaitForVisiblityAndClickOrAbortHotkeyEvent(this IRenderController renderController, string path,
            int maxWaitTimeMs = 2000, int intervalMs = 25, bool leftClick = true)
        {
            WaitForConditionOrAbortHotkeyEvent(() => renderController.IsUiElementVisible(path), maxWaitTimeMs, intervalMs);
            if (leftClick)
                renderController.GetOrRegisterAndGetUiElement(path).Click();
            else
                renderController.GetOrRegisterAndGetUiElement(path).RightClick();
        }

        public static void WaitForConditionOrAbortHotkeyEvent(Func<bool> condition, int maxWaitTimeMs = 2000, int intervalMs = 25)
        {
            var result = new TimedRetryExecutor(maxWaitTimeMs, intervalMs, condition).Invoke();

            if (!result)
                Logger.warn("WaitForConditionOrAbortHotkeyEvent - Condition was not met after max time elapsed: " + condition.Method);
        }

        public static void CloseChatAndOpenWindows(this IRenderController renderController)
        {
            if (renderController.IsUiElementVisible(UiPathConstants.Ui.CHAT_INPUT))
            {
                InputSimulator.PressKey(Keys.Escape);
                WaitForConditionOrAbortHotkeyEvent(() => !renderController.IsUiElementVisible(UiPathConstants.Ui.CHAT_INPUT));
            }

            InputSimulator.PressKey(Settings.Keybinds[(int)ActionKey.Close]);
            Thread.Sleep(25);
        }

        public static bool IsUiElementVisible(this IRenderController renderController, string path)
        {
            var uiElement = renderController.GetOrRegisterAndGetUiElement(path);
            return !(uiElement is null) && uiElement.Visible;
        }

        public static IUiElement GetOrRegisterAndGetUiElement(this IRenderController renderController, string path)
        {
            var layer = renderController.GetUiElement(path) ??
                        renderController.RegisterUiElement(path, null, null);

            return layer;
        }

        public static bool IsShopOpen(this IRenderController renderController)
        {
            return renderController.IsUiElementVisible(UiPathConstants.Vendor.CURRENCY_TYPE);
        }
    }
}