namespace Turbo.Plugins.Patrick
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;
    using Default;
    using forms;
    using plugins.patrick.skills;
    using plugins.patrick.util.config;
    using plugins.patrick.util.diablo;
    using plugins.patrick.util.thud;

    public class pHelper : BasePlugin, IInGameTopPainter, IKeyEventHandler, IAfterCollectHandler, INewAreaHandler
    {
        private IFont watermarkEnabled, watermarkDisabled, version;

        private IBrush activeSkillBrush, inactiveSkillBrush;

        private Settings settings;

        private SkillExecutor skillExecutor;

        private Thread settingsThread;

        public pHelper()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            settings = new Settings(Hud);
            skillExecutor = new SkillExecutor(settings);

            settingsThread = new Thread(() =>
            {
                settings.ShowDialog();
            });
            settingsThread.SetApartmentState(ApartmentState.STA);
            settingsThread.Start();

            watermarkEnabled = Hud.Render.CreateFont("tahoma", 8, 255, 0, 170, 0, true, false, false);
            watermarkDisabled = Hud.Render.CreateFont("tahoma", 8, 255, 170, 0, 0, true, false, false);

            version = Hud.Render.CreateFont("tahoma", 8, 255, 227, 227, 0, false, false, false);

            activeSkillBrush = settings.Hud.Render.CreateBrush(255, 0, 170, 0, 3.14f);
            inactiveSkillBrush = settings.Hud.Render.CreateBrush(255, 170, 0, 0, 3.14f);
        }

        public void OnNewArea(bool newGame, ISnoArea area)
        {
            if (newGame)
                settings.cb_ShowOnlyForCurrentClass_CheckedChanged(null, null);
        }

        public void OnKeyEvent(IKeyEvent keyEvent)
        {
            settings.Hotkeys.InvokeIfExists(keyEvent, Hud);
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip)
                return;
            
            DrawSkillBrushes();

            if (Settings.Active)
                watermarkEnabled.DrawText("pHelper", 4, Hud.Window.Size.Height * 0.966f);
            else
                watermarkDisabled.DrawText("pHelper", 4, Hud.Window.Size.Height * 0.966f);
            
            if (Hud.Window.CursorInsideRect(4, Hud.Window.Size.Height * 0.966f, 70, 20))
                version.DrawText("v" + Config.VERSION, 4, Hud.Window.Size.Height * 0.946f);
        }

        public void AfterCollect()
        {
            if (Hud.Game.IsLoading || Hud.Game.IsPaused || !D3Client.IsInForeground() || !Settings.Active)
                return;

            settings.AutoActions.ExecuteAutoActions(Hud);

            if (CharacterCanCast())
                ExecuteClassMacros();
        }

        private void DrawSkillBrushes()
        {
            Hud.Game.Me.Powers.UsedSkills.ForEach(skill =>
            {
                if (!settings.SnoToDefinitionGroups.TryGetValue(skill.SnoPower.Sno, out var definitionGroupsForSkill) || !definitionGroupsForSkill.active || !Settings.KeyToActive[skill.Key])
                    inactiveSkillBrush.DrawRectangle(settings.Hud.Render.GetPlayerSkillUiElement(skill.Key).Rectangle);
                else
                    activeSkillBrush.DrawRectangle(settings.Hud.Render.GetPlayerSkillUiElement(skill.Key).Rectangle);
            });
        }

        private void ExecuteClassMacros()
        {
            Hud.Game.Me.Powers.CurrentSkills.ForEach(skill =>
                skillExecutor.Cast(skill)
            );
        }
        
        private bool CharacterCanCast()
        {
            Hud.Debug($"ingrift: {Hud.Game.SpecialArea}");
            if (Hud.Game.Quests.FirstOrDefault(quest => quest.SnoQuest.Sno == Hud.Sno.SnoQuests.NephalemRift_337492.Sno) is IQuest riftQuest)
                if (riftQuest.QuestStepId == 34)
                    return false;


            return Hud.Game.IsInGame
                   && !Hud.Game.IsInTown
                   && !Hud.Game.IsLoading
                   && Hud.Game.MapMode == MapMode.Minimap
                   && !Hud.Game.Me.IsDead
                   && Hud.Game.Me.AnimationState != AcdAnimationState.CastingPortal
                   && !Hud.Render.IsUiElementVisible(UiPathConstants.Ui.CHAT_INPUT)
                   && !Hud.Game.Me.Powers.BuffIsActive(Hud.Sno.SnoPowers.Generic_ActorInvulBuff.Sno)
                   && !Hud.Game.Me.Powers.BuffIsActive(Hud.Sno.SnoPowers.Generic_TeleportToPlayerCast.Sno)
                   && !Hud.Game.Me.Powers.BuffIsActive(Hud.Sno.SnoPowers.Generic_TeleportToWaypointCast.Sno)
                   && !Hud.Game.Me.Powers.BuffIsActive(Hud.Sno.SnoPowers.Generic_AxeOperateGizmo.Sno);
        }
    }
}