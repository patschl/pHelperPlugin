namespace Turbo.plugins.patrick.util.thud
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Plugins;
    using Plugins.Default;
    using Plugins.Patrick.util;
    using SharpDX.Direct2D1;
    using SharpDX.DirectWrite;

    public class ActivePowerOverlay : BasePlugin, IInGameTopPainter
    {
        private IFont watermark, tableHeadingFont, tableRow, tableRowB, deltaTableRow;

        private IBrush background;

        private TextLayout tableHeadingLayout;

        private readonly List<IBuff> initialBuffs = new List<IBuff>();

        private readonly HashSet<IBuff> buffDelta = new HashSet<IBuff>();

        private readonly Dictionary<uint, string> oldTableEntries = new Dictionary<uint, string>();

        private float coordX, coordY;

        private int currentRowIndex;

        private string heading;

        private const string WATERMARK_TEXT = "- ActivePowerOverlay";

        private const string ROW_FORMATTER = "# {0:00})  {1,-12}{2,-10}{3,-40}{4,-80}";

        private const string TIME_LEFT_ENTRY_FORMATTER = "<#[{0}] ({1:F1}/{2:F1}) Stacks: {3}> ";

        private const string COUNT_ENTRY_FORMATTER = "<#[{0}] Stacks: {1}> ";

        private readonly uint[] excludedBuffs =
        {
            220304, // ActorInTownBuff
            439438, // ActorInvulBuff
            212032, // ActorLoadingBuff
            134334, // Banter_Cooldown
            30145, // BareHandedPassive
            225599, // CannotDieDuringBuff
            134225, // Callout_Cooldown
            30176, // Cooldown
            428398, // Cosmetic_SpectralHound_Buff
            193438, // DualWieldBuff
            257687, // Enchantress_MissileWard
            286747, // g_paragonBuff
            30283, // ImmuneToFearDuringBuff
            30284, // ImmuneToRootDuringBuff
            30285, // ImmuneToSnareDuringBuff
            30286, // ImmuneToStunDuringBuff
            30290, // InvulnerableDuringBuff
            349060, // TeleportToWaypoint
            371141, // TeleportToWaypoint_Cast
            79486, // UninterruptibleDuringBuff
            30582, // UntargetableDuringBuff
            30584, // UseHealthGlyph
            132910, // WarpInMagical
            223604, // WorldCreatingBuff
        };

        public ActivePowerOverlay()
        {
            Enabled = false;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            watermark = Hud.Render.CreateFont("tahoma", 8, 255, 227, 227, 0, true, false, false);
            tableHeadingFont = Hud.Render.CreateFont("Courier New", 8, 255, 255, 255, 255, true, false, true);

            tableRow = Hud.Render.CreateFont("Courier New", 8, 255, 255, 69, 80, false, false, true);
            tableRowB = Hud.Render.CreateFont("Courier New", 8, 255, 0, 123, 167, false, false, true);
            deltaTableRow = Hud.Render.CreateFont("Courier New", 8, 255, 0, 222, 2, false, false, true);

            background = Hud.Render.CreateBrush(70, 0, 0, 0, 0);

            coordX = Hud.Window.Size.Width * 0.1f;
            coordY = Hud.Window.Size.Height * 0.16f;

            heading = string.Format(ROW_FORMATTER, "ID", "[ACTIVE] ", "[SNO]", "[Name / (Code)]", "[#INDEX (TIMLEFT/TOTAL TIME) #STACKS]");
        }

        public void PaintTopInGame(ClipState clipState)
        {
            watermark.DrawText(WATERMARK_TEXT, Hud.Window.Size.Width * 0.04f, Hud.Window.Size.Height * 0.966f);
            tableHeadingLayout = tableHeadingFont.GetTextLayout(heading);
            tableHeadingFont.DrawText(tableHeadingLayout, coordX, coordY);

            currentRowIndex = 0;

            var buffs = Hud.Game.Me.Powers.AllBuffs.Where(buff => buff.Active && !excludedBuffs.Contains(buff.SnoPower.Sno))
                .OrderBy(power => power.SnoPower.Sno).ToList();

            if (initialBuffs.Count == 0)
                initialBuffs.AddRange(buffs);

            var tableEntries = new List<string>();
            buffs.ForEach(buff =>
            {
                if (!initialBuffs.Contains(buff))
                {
                    buffDelta.Add(buff);
                    return;
                }

                if (!(GetBuffRow(buff) is string row))
                    return;
                tableEntries.Add(row);
            });

            var deltaTableEntries = GetDeltaBuffTableEntries();

            background.DrawRectangle(coordX - 10, coordY - 10, Hud.Window.Size.Width * 0.7f,
                ((tableEntries.Count + deltaTableEntries.Count + 1) * 19f) + 20);

            tableEntries.ForEachWithIndex((entry, index) =>
            {
                var font = index % 2 == 0 ? tableRow : tableRowB;
                font.DrawText(entry, coordX, coordY + ((index + 1) * 19f));
            });

            deltaTableEntries.ForEachWithIndex((entry, index) =>
            {
                deltaTableRow.DrawText(entry, coordX, coordY + ((tableEntries.Count + index + 1) * 19f));
            });
        }

        private List<string> GetDeltaBuffTableEntries()
        {
            var newTableEntries = new List<string>();

            buffDelta.ForEach(buff =>
            {
                if (GetBuffRow(buff) is string row)
                {
                    newTableEntries.Add(row);
                    var cachedRow = Regex.Replace(row, @"(\bTrue\b|\bFalse\b)", "<CACHED>");
                    if (oldTableEntries.ContainsKey(buff.SnoPower.Sno))
                        oldTableEntries[buff.SnoPower.Sno] = cachedRow;
                    else
                        oldTableEntries.Add(buff.SnoPower.Sno, cachedRow);
                }
                else
                    newTableEntries.Add(oldTableEntries[buff.SnoPower.Sno]);
            });

            return newTableEntries;
        }

        private string GetBuffRow(IBuff buff)
        {
            var timeLeftAndStacks = string.Empty;

            for (var iconIndex = 0; iconIndex < buff.TimeLeftSeconds.Length; iconIndex++)
                timeLeftAndStacks = string.Concat(timeLeftAndStacks, GetIconIndexValue(buff, iconIndex));

            if (timeLeftAndStacks == string.Empty)
                return null;

            var nameOrCode = buff.SnoPower.NameEnglish == null ? $"({buff.SnoPower.Code})" : $"{buff.SnoPower.NameEnglish}";
            return string.Format(ROW_FORMATTER, ++currentRowIndex, buff.Active.ToString(), buff.SnoPower.Sno, nameOrCode,
                timeLeftAndStacks);
        }

        private static string GetIconIndexValue(IBuff buff, int iconIndex)
        {
            var entry = string.Empty;

            if (buff.TimeLeftSeconds[iconIndex] > 0)
                entry = string.Format(TIME_LEFT_ENTRY_FORMATTER, iconIndex, buff.TimeLeftSeconds[iconIndex],
                    buff.TimeLeftSeconds[iconIndex] + buff.TimeElapsedSeconds[iconIndex], buff.IconCounts[iconIndex]);
            else if (buff.IconCounts[iconIndex] > 0)
                entry = string.Format(COUNT_ENTRY_FORMATTER, iconIndex, buff.IconCounts[iconIndex]);

            return entry;
        }

        public void Reset()
        {
            initialBuffs.Clear();
            buffDelta.Clear();
            oldTableEntries.Clear();
        }
    }
}