namespace Turbo.plugins.patrick.util.diablo
{
    public static class UiPathConstants
    {
        public static class Buttons
        {
			public const string START_GAME = "Root.NormalLayer.BattleNetCampaign_main.LayoutRoot.Menu.PlayGameButton";
            public const string LEAVE_GAME = "Root.NormalLayer.gamemenu_dialog.gamemenu_bkgrnd.ButtonStackContainer.button_leaveGame";
            public const string GAME_MENU = "Root.NormalLayer.game_dialog_backgroundScreenPC.button_menu";
            public const string INVENTORY = "Root.NormalLayer.game_dialog_backgroundScreenPC.button_inventory";
        }
        
        public static class WaitpointMap
        {
            public const string ZOOM_OUT = "Root.NormalLayer.WaypointMap_main.LayoutRoot.OverlayContainer.Zoom.ZoomOut";

            public const string ACT_ONE = "Root.NormalLayer.WaypointMap_main.LayoutRoot.OverlayContainer.WorldMap.Act1Open.LayoutRoot.Interest";
            public const string ACT_TWO = "Root.NormalLayer.WaypointMap_main.LayoutRoot.OverlayContainer.WorldMap.Act2Open.LayoutRoot.Interest";
            public const string ACT_THREE = "Root.NormalLayer.WaypointMap_main.LayoutRoot.OverlayContainer.WorldMap.Act3Open.LayoutRoot.Interest";
            public const string ACT_FOUR = "Root.NormalLayer.WaypointMap_main.LayoutRoot.OverlayContainer.WorldMap.Act4Open.LayoutRoot.Interest";
            public const string ACT_FIVE = "Root.NormalLayer.WaypointMap_main.LayoutRoot.OverlayContainer.WorldMap.Act5Open.LayoutRoot.Interest";
            
            public static class ActOne
            {
                public const string TOWN = "Root.NormalLayer.WaypointMap_main.LayoutRoot.OverlayContainer.POI.entry 0.LayoutRoot.Interest";    
            }
            public static class ActTwo
            {
                public const string TOWN = "Root.NormalLayer.WaypointMap_main.LayoutRoot.OverlayContainer.POI.entry 19.LayoutRoot.Interest";    
            }
            public static class ActThree
            {
                public const string TOWN = "Root.NormalLayer.WaypointMap_main.LayoutRoot.OverlayContainer.POI.entry 30.LayoutRoot.Interest";    
            }
            public static class ActFour
            {
                public const string TOWN = "Root.NormalLayer.WaypointMap_main.LayoutRoot.OverlayContainer.POI.entry 44.LayoutRoot.Interest";    
            }
            public static class ActFive
            {
                public const string TOWN = "Root.NormalLayer.WaypointMap_main.LayoutRoot.OverlayContainer.POI.entry 58.LayoutRoot.Interest";    
            }
        }

        public static class Blacksmith
        {
            public const string UNIQUE_PAGE = "Root.NormalLayer.vendor_dialog_mainPage.tab_4";
            
            public const string SALVAGE_PAGE = "Root.NormalLayer.vendor_dialog_mainPage.tab_2";
            public const string SALVAGE_DIALOG = "Root.TopLayer.confirmation.subdlg";
            public const string SALVAGE_DIALOG_OK = "Root.TopLayer.confirmation.subdlg.stack.wrap.button_ok";
            
            public const string VENDOR_SALVAGE = "Root.NormalLayer.vendor_dialog_mainPage.salvage_dialog.salvage_all_wrapper";

            public const string ANVIL = "Root.NormalLayer.vendor_dialog_mainPage.salvage_dialog.salvage_all_wrapper.salvage_button";
            public const string SALVAGE_RARE = "Root.NormalLayer.vendor_dialog_mainPage.salvage_dialog.salvage_all_wrapper.salvage_rare_button";
            public const string SALVAGE_BLUE = "Root.NormalLayer.vendor_dialog_mainPage.salvage_dialog.salvage_all_wrapper.salvage_magic_button";
            public const string SALVAGE_WHITE = "Root.NormalLayer.vendor_dialog_mainPage.salvage_dialog.salvage_all_wrapper.salvage_normal_button";
        }

        public static class Ui
        {
            public const string CHAT_INPUT = "Root.NormalLayer.chatentry_dialog_backgroundScreen.chatentry_content.chat_editline";
        }

        public static class RiftObelisk
        {
            public const string OBELISK_WINDOW = "Root.NormalLayer.rift_dialog_mainPage";
            public const string NORMAL_RIFT_BUTTON = "Root.NormalLayer.rift_dialog_mainPage.LayoutRoot.RiftRadioButtons.NephalemRiftButton";
            public const string GREATER_RIFT_BUTTON = "Root.NormalLayer.rift_dialog_mainPage.LayoutRoot.RiftRadioButtons.GreaterRiftButton";
            public const string EMPOWERED_CHECKBOX =
                "Root.NormalLayer.rift_dialog_mainPage.LayoutRoot.EmpoweredRiftToggleWrapper.EmpoweredRiftToggle.box";
            public const string ACCEPT_BUTTON = "Root.NormalLayer.rift_dialog_mainPage.LayoutRoot.accept_Button";
        }

        public static class Paragon
        {
            public const string NEW_PARAGON_BUTTON = "Root.NormalLayer.game_notify_dialog_backgroundScreen.dlg_new_paragon.button";
            
            public const string PARAGON_TAB_CORE = "Root.NormalLayer.Paragon_main.LayoutRoot.ParagonPointSelect.tab_1";
            public const string PARAGON_TAB_OFFENSE = "Root.NormalLayer.Paragon_main.LayoutRoot.ParagonPointSelect.tab_2";
            public const string PARAGON_TAB_DEFENSE = "Root.NormalLayer.Paragon_main.LayoutRoot.ParagonPointSelect.tab_3";
            public const string PARAGON_TAB_UTILITY = "Root.NormalLayer.Paragon_main.LayoutRoot.ParagonPointSelect.tab_4";

            public const string PARAGON_UNSPENT_CORE = "Root.NormalLayer.Paragon_main.LayoutRoot.ParagonPointSelect.Points_Available_1";
            public const string PARAGON_UNSPENT_OFFENSE = "Root.NormalLayer.Paragon_main.LayoutRoot.ParagonPointSelect.Points_Available_2";
            public const string PARAGON_UNSPENT_DEFENSE = "Root.NormalLayer.Paragon_main.LayoutRoot.ParagonPointSelect.Points_Available_3";
            public const string PARAGON_UNSPENT_UTILITY = "Root.NormalLayer.Paragon_main.LayoutRoot.ParagonPointSelect.Points_Available_4";

            public const string PARAGON_BUTTON_FIRST = "Root.NormalLayer.Paragon_main.LayoutRoot.ParagonPointSelect.Bonuses.bonus0.IncreaseStat";
            public const string PARAGON_BUTTON_SECOND = "Root.NormalLayer.Paragon_main.LayoutRoot.ParagonPointSelect.Bonuses.bonus1.IncreaseStat";
            public const string PARAGON_BUTTON_THIRD = "Root.NormalLayer.Paragon_main.LayoutRoot.ParagonPointSelect.Bonuses.bonus2.IncreaseStat";
            public const string PARAGON_BUTTON_FOURTH =  "Root.NormalLayer.Paragon_main.LayoutRoot.ParagonPointSelect.Bonuses.bonus3.IncreaseStat";

            public const string PARAGON_BUTTON_RESET =  "Root.NormalLayer.SkillPane_main.LayoutRoot.ParagonPointSelect.ResetParagonPointsButton";
            public const string PARAGON_BUTTON_ACCEPT = "Root.NormalLayer.Paragon_main.LayoutRoot.ParagonPointSelect.AcceptParagonPointsButton";
            public const string PARAGON_BUTTON_CLOSE =  "Root.NormalLayer.Paragon_main.LayoutRoot.ParagonPointSelect.CancelParagonPointsButton";
        }

        public static class Vendor
        {
            public const string FIRST_TAB = "Root.NormalLayer.shop_dialog_mainPage.tab_0";
            public const string SECOND_TAB = "Root.NormalLayer.shop_dialog_mainPage.tab_1";
            public const string THIRD_TAB = "Root.NormalLayer.shop_dialog_mainPage.tab_2";
            public const string FOURTH_TAB = "Root.NormalLayer.shop_dialog_mainPage.tab_3";
            public const string FIFTH_TAB = "Root.NormalLayer.shop_dialog_mainPage.tab_4";

            public const string FIRST_ITEM = "Root.NormalLayer.shop_dialog_mainPage.shop_item_region.item 0 0";
            public const string SECOND_ITEM = "Root.NormalLayer.shop_dialog_mainPage.shop_item_region.item 1 0";
            public const string THIRD_ITEM = "Root.NormalLayer.shop_dialog_mainPage.shop_item_region.item 0 1";
            public const string FOURTH_ITEM = "Root.NormalLayer.shop_dialog_mainPage.shop_item_region.item 1 1";
            public const string FIFTH_ITEM = "Root.NormalLayer.shop_dialog_mainPage.shop_item_region.item 0 2";
            public const string SIXTH_ITEM = "Root.NormalLayer.shop_dialog_mainPage.shop_item_region.item 1 2";
            public const string SEVENTH_ITEM = "Root.NormalLayer.shop_dialog_mainPage.shop_item_region.item 0 3";
            public const string EIGHTH_ITEM = "Root.NormalLayer.shop_dialog_mainPage.shop_item_region.item 1 3";
            public const string NINTH_ITEM = "Root.NormalLayer.shop_dialog_mainPage.shop_item_region.item 0 4";
            public const string TENTH_ITEM = "Root.NormalLayer.shop_dialog_mainPage.shop_item_region.item 1 4";
            public const string ELEVENTH_ITEM = "Root.NormalLayer.shop_dialog_mainPage.shop_item_region.item 0 5";
            public const string TWELFTH_ITEM = "Root.NormalLayer.shop_dialog_mainPage.shop_item_region.item 1 5";

            public const string CURRENCY_TYPE = "Root.NormalLayer.shop_dialog_mainPage.gold_text";

            public const string CLOSE_BUTTON = "Root.NormalLayer.shop_dialog_mainPage.button_exit";
        }
    }
}