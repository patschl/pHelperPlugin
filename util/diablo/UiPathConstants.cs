namespace Turbo.plugins.patrick.util.diablo
{
    public static class UiPathConstants
    {
        public static class Buttons
        {
            public const string LEAVE_GAME = "Root.NormalLayer.gamemenu_dialog.gamemenu_bkgrnd.ButtonStackContainer.button_leaveGame";
            public const string GAME_MENU = "Root.NormalLayer.game_dialog_backgroundScreenPC.button_menu";
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
    }
}