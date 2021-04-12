namespace Turbo.plugins.patrick.util.thud
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using diablo;
    using executors;
    using input;
    using Plugins;
    using Plugins.Patrick.forms;
    using Plugins.Patrick.util;

    public static class RenderControllerFunctions
    {
        public static void WaitForVisiblityAndClickOrAbortHotkeyEvent(this IRenderController renderController, string path, int maxWaitTimeMs = 2000, int intervalMs = 25)
        {
            WaitForConditionOrAbortHotkeyEvent(() => renderController.IsUiElementVisible(path), maxWaitTimeMs, intervalMs);
            renderController.GetOrRegisterAndGetUiElement(path).Click();
        }

        public static void WaitForConditionOrAbortHotkeyEvent(Func<bool> condition, int maxWaitTimeMs = 2000, int intervalMs = 25)
        {
            var result = new TimedRetryExecutor(maxWaitTimeMs, intervalMs, condition).Invoke();

            if (!result)
                throw new InvalidOperationException("Failed to execute macro! Condition was not met after max time elapsed: " + condition.Method);
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
    }
}