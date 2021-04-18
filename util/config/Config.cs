namespace Turbo.plugins.patrick.util.config
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using autoactions.actions;
    using hotkeys.actions;
    using logger;
    using Newtonsoft.Json;
    using Plugins;
    using Plugins.Default;
    using Plugins.Patrick.autoactions;
    using Plugins.Patrick.forms;
    using Plugins.Patrick.hotkeys;
    using skills;

    public static class Config
    {
        public const string VERSION = "0.9.2-BETA";
        
        private const string DEFINITION_BASE_PATH = @"config\phelper\definitions";
        private const string KEYBINDS_CONFIG_PATH = @"config\phelper\keybinds.json";
        private const string HOTKEYS_CONFIG_PATH = @"config\phelper\hotkeys.json";
        private const string AUTO_ACTIONS_CONFIG_PATH = @"config\phelper\autoactions.json";

        public const int QOL_KEY_INDEX = 1337;

        public static void SaveKeybinds(Dictionary<int, Keys> keybinds)
        {
            ValidateDirExists();

            File.WriteAllText(
                KEYBINDS_CONFIG_PATH,
                JsonConvert.SerializeObject(keybinds, Formatting.Indented)
            );
        }

        public static Dictionary<int, Keys> LoadKeybinds()
        {
            return !File.Exists(KEYBINDS_CONFIG_PATH)
                ? GetDefaultKeybinds()
                : LoadObjectFromFile<Dictionary<int, Keys>>(KEYBINDS_CONFIG_PATH) ?? GetDefaultKeybinds();
        }

        public static void SaveHotkeys(HotkeyContainer hotkeyContainer)
        {
            ValidateDirExists();

            File.WriteAllText(
                HOTKEYS_CONFIG_PATH,
                JsonConvert.SerializeObject(hotkeyContainer, Formatting.Indented)
            );
        }

        public static HotkeyContainer LoadHotkeyContainer()
        {
            if (!File.Exists(HOTKEYS_CONFIG_PATH))
                return new HotkeyContainer(GetAllHotkeys());

            var hotkeyContainer = LoadObjectFromFile<HotkeyContainer>(HOTKEYS_CONFIG_PATH) ?? new HotkeyContainer();
            AddMissingHotkeys(hotkeyContainer);

            return hotkeyContainer;
        }

        public static void SaveAutoActions(AutoActionContainer actionContainer)
        {
            ValidateDirExists();

            File.WriteAllText(
                AUTO_ACTIONS_CONFIG_PATH,
                JsonConvert.SerializeObject(actionContainer, Formatting.Indented)
            );
        }

        public static AutoActionContainer LoadAutoActions()
        {
            if (!File.Exists(AUTO_ACTIONS_CONFIG_PATH))
                return new AutoActionContainer(GetAllAutoActions());

            var autoActionContainer = LoadObjectFromFile<AutoActionContainer>(AUTO_ACTIONS_CONFIG_PATH) ?? new AutoActionContainer();
            AddMissingAutoActions(autoActionContainer);

            return autoActionContainer;
        }

        public static void SaveDefinitions(Dictionary<uint, DefinitionGroupsForSkill> definitions)
        {
            (definitions ?? new Dictionary<uint, DefinitionGroupsForSkill>())
                .Select(definition => definition.Value)
                .ForEach(SaveDefinitionGroupsForSkill);
        }

        public static Dictionary<string, Dictionary<uint, DefinitionGroupsForSkill>> LoadDefinitions2()
        {
            var configProfiles = new Dictionary<string, Dictionary<uint, DefinitionGroupsForSkill>>();
            var profilePaths = Directory.GetDirectories(DEFINITION_BASE_PATH);
            profilePaths.ForEach(path =>
            {
                configProfiles.Add(path.Substring(path.LastIndexOf('\\') + 1), LoadDefinitions(path));
            });
            
            if (configProfiles.Count == 0)
                configProfiles.Add("Default", new Dictionary<uint, DefinitionGroupsForSkill>());

            return configProfiles;
        }

        public static Dictionary<uint, DefinitionGroupsForSkill> LoadDefinitions(string path)
        {
            var definitions = new Dictionary<uint, DefinitionGroupsForSkill>();

            if (!Directory.Exists(path))
                return definitions;

            var configFilePaths = Directory.GetFiles(path, "*.json", SearchOption.AllDirectories);

            foreach (var configFilePath in configFilePaths)
            {
                var definitionGroup = LoadDefinitionGroupFromFile(configFilePath);

                if (definitionGroup is null)
                    continue;

                if (!definitions.ContainsKey(definitionGroup.sno))
                    definitions.Add(definitionGroup.sno, CreateDefinitionGroupsForSkill(configFilePath));

                definitions[definitionGroup.sno].definitionGroups.Add(definitionGroup);
            }

            SetAllParentDefinitionGroups(definitions);

            return definitions;
        }

        private static void SetAllParentDefinitionGroups(Dictionary<uint, DefinitionGroupsForSkill> definitions)
        {
            definitions.ForEach(
                definitionGroup => definitionGroup.Value.definitionGroups.ForEach(SetParentDefinitionGroup)
            );
        }

        private static void SetParentDefinitionGroup(DefinitionGroup definitionGroup)
        {
            definitionGroup.definitions.ForEach(definition => definition.SetParentDefinitionGroup(definitionGroup));
        }

        private static DefinitionGroupsForSkill CreateDefinitionGroupsForSkill(string configFilePath)
        {
            var splitFilePath = configFilePath.Split('\\');
            var profileName = splitFilePath[splitFilePath.Length - 4];
            var heroName = splitFilePath[splitFilePath.Length - 3];
            var skillName = splitFilePath[splitFilePath.Length - 2];

            return new DefinitionGroupsForSkill(heroName, skillName, profileName);
        }

        private static DefinitionGroup LoadDefinitionGroupFromFile(string configFilePath)
        {
            return LoadObjectFromFile<DefinitionGroup>(configFilePath);
        }

        public static void SaveDefinitionGroupsForSkill(DefinitionGroupsForSkill definitionGroupsForSkill)
        {
            var dirPath = $@"config\phelper\definitions\{definitionGroupsForSkill.configProfileName}\{definitionGroupsForSkill.heroClassName}\{definitionGroupsForSkill.skillName}\";
            Directory.CreateDirectory(dirPath);

            definitionGroupsForSkill.definitionGroups.ForEach(definitionGroup =>
                File.WriteAllText(
                    dirPath + definitionGroup.name + ".json",
                    JsonConvert.SerializeObject(definitionGroup, Formatting.Indented)
                )
            );
        }

        private static void AddMissingHotkeys(HotkeyContainer hotkeyContainer)
        {
            var existingHotkeyTypes = hotkeyContainer.hotkeyActions.Select(hotkey => hotkey.GetType()).ToList();
            var missingHotkeys = AbstractHotkeyAction.HotkeyTypes
                .Except(existingHotkeyTypes)
                .Select(type => (AbstractHotkeyAction)Activator.CreateInstance(type));

            hotkeyContainer.hotkeyActions.AddRange(missingHotkeys);
        }

        private static List<AbstractHotkeyAction> GetAllHotkeys()
        {
            return AbstractHotkeyAction.HotkeyTypes
                .Select(type => (AbstractHotkeyAction)Activator.CreateInstance(type))
                .ToList();
        }

        private static void AddMissingAutoActions(AutoActionContainer actionContainer)
        {
            var existingHotkeyTypes = actionContainer.autoActions.Select(hotkey => hotkey.GetType()).ToList();
            var missingAutoActions = AbstractAutoAction.AutoActionTypes
                .Except(existingHotkeyTypes)
                .Select(type => (AbstractAutoAction)Activator.CreateInstance(type));

            actionContainer.autoActions.AddRange(missingAutoActions);
        }

        private static List<AbstractAutoAction> GetAllAutoActions()
        {
            return AbstractAutoAction.AutoActionTypes
                .Select(type => (AbstractAutoAction)Activator.CreateInstance(type))
                .ToList();
        }

        private static Dictionary<int, Keys> GetDefaultKeybinds()
        {
            return new Dictionary<int, Keys>
            {
                {(int)ActionKey.LeftSkill, Keys.LButton},
                {(int)ActionKey.RightSkill, Keys.RButton},
                {(int)ActionKey.Skill1, Keys.D1},
                {(int)ActionKey.Skill2, Keys.D2},
                {(int)ActionKey.Skill3, Keys.D3},
                {(int)ActionKey.Skill4, Keys.D4},
                {(int)ActionKey.Heal, Keys.Q},
                {(int)ActionKey.Close, Keys.E},
                {(int)ActionKey.Map, Keys.M},
                {(int)ActionKey.Move, Keys.MButton},
                {(int)ActionKey.Unknown, Keys.ShiftKey}, // Using unknown for ForceStand
                {QOL_KEY_INDEX, Keys.XButton1}
            };
        }

        private static void ValidateDirExists()
        {
            const string dirPath = @"config\phelper\";
            Directory.CreateDirectory(dirPath);
        }

        private static T LoadObjectFromFile<T>(string filePath) where T : class
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    $"Failed to load definition group from file: {filePath}! Check log for further information",
                    "Failed to load config", MessageBoxButtons.OK);

                Logger.error($"Failed to load definition group: {filePath}. Reason: {e}");
            }

            return null;
        }

        public static void SetKeybindAndSaveConfig(int key, ComboBox bind)
        {
            Settings.Keybinds[key] = (Keys)bind.SelectedItem;
            SaveKeybinds(Settings.Keybinds);
        }
    }
}