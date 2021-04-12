namespace Turbo.Plugins.Patrick
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Default;
    using forms;
    using plugins.patrick.skills;
    using plugins.patrick.util;
    using plugins.patrick.util.diablo;
    using plugins.patrick.util.thud;
    using SharpDX.DirectInput;
    using util;

    public class pHelper : BasePlugin, IInGameTopPainter, IKeyEventHandler, IAfterCollectHandler
    {
        private IFont watermark;

        private Settings settings;

        private SkillExecutor skillExecutor;

        private Thread settingsThread;

        private IKeyEvent showSettingsWindowHotkey;

        public pHelper()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            settings = new Settings(Hud);
            skillExecutor = new SkillExecutor(settings);
            showSettingsWindowHotkey = hud.Input.CreateKeyEvent(true, Key.F10, true, false, false);

            settingsThread = new Thread(() =>
            {
                settings.ShowDialog();
            });
            settingsThread.SetApartmentState(ApartmentState.STA);
            settingsThread.Start();

            watermark = Hud.Render.CreateFont("tahoma", 8, 255, 255, 0, 0, true, false, false);
        }

        public void OnKeyEvent(IKeyEvent keyEvent)
        {
            if (keyEvent.Matches(showSettingsWindowHotkey))
                dump();
            else
                settings.Hotkeys.InvokeIfExists(keyEvent, Hud);
        }

        private void dump()
        {
            var button = Hud.Render.GetOrRegisterAndGetUiElement(UiPathConstants.RiftObelisk.EMPOWERED_CHECKBOX);

            Hud.Debug($"text: {button.ReadText(Encoding.UTF8, true)} state: {button.AnimState} sno {button.TextureSno}");
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip)
                return;

            watermark.DrawText(watermark.GetTextLayout("pHelper"), 4, Hud.Window.Size.Height * 0.966f);
        }

        public void AfterCollect()
        {
            if (Hud.Game.IsLoading || Hud.Game.IsPaused)
                return;

            settings.AutoActions.ExecuteAutoActions(Hud);

            if (CharacterCanCast())
                ExecuteClassMacros();
        }

        private void ExecuteClassMacros()
        {
            var me = Hud.Game.Me;

            if (!me.Powers.HealthPotionSkill.IsOnCooldown && me.Defense.HealthCur <= me.Defense.HealthMax * 0.35)
                me.Powers.HealthPotionSkill.Cast();

            me.Powers.CurrentSkills.ForEach(skill =>
                skillExecutor.Cast(skill)
            );
        }

        private bool CharacterCanCast()
        {
            return Hud.Game.IsInGame
                   && !Hud.Game.IsInTown
                   && !Hud.Game.IsLoading
                   && !Hud.Render.UiHidden
                   && Hud.Game.MapMode == MapMode.Minimap
                   && !Hud.Game.Me.IsDead
                   && Hud.Game.Me.AnimationState != AcdAnimationState.CastingPortal;
        }
    }
}