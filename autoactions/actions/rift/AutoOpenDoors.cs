namespace Turbo.plugins.patrick.autoactions.actions.rift
{
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using Plugins;
    using util.thud;

    public class AutoOpenDoors : AbstractAutoAction
    {
        public override string GetAttributes() => $"";
        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>();
        }

        public override bool Applicable(IController hud)
        {
            return !hud.Game.IsInTown && !hud.Game.Me.IsDead && hud.Game.Doors.Any(door => door.CentralXyDistanceToMe <= 12 && !DoorBlacklist.Contains(door.SnoActor.Sno));
        }

        public override void Invoke(IController hud)
        {
            hud.Game.Doors.FirstOrDefault(door => door.CentralXyDistanceToMe <= 12 && !DoorBlacklist.Contains(door.SnoActor.Sno))?.Click(hud.Window.Offset);
        }
        
        // Credits to JackCeparou (https://github.com/JackCeparou/JackCeparouCompass/blob/master/Actors/DoorsPlugin.cs) 
        private static readonly HashSet<ActorSnoEnum> DoorBlacklist = new HashSet<ActorSnoEnum>() {
            ActorSnoEnum._cald_merchant_cart, // A2 to belial
			ActorSnoEnum._a2dun_cald_exit_gate, // A2 to belial
			ActorSnoEnum._a2dunswr_gates_causeway_gates_non_op, // A2 to belial
			ActorSnoEnum._a2dun_cald_belial_acid_attack, // A2 to belial
			ActorSnoEnum._a2dun_cald_belial_room_gate_a, // A2 to belial
            ActorSnoEnum._trout_cultists_summoning_portal_b, // A2 Alcarnus
            ActorSnoEnum._caout_target_dummy, // A2 City
			ActorSnoEnum._start_location_team_0, // A2 City
            ActorSnoEnum._a3dun_crater_st_demon_chainpylon_fire_azmodan, // A3 rakkis crossing
			ActorSnoEnum._a3dun_keep_bridge, // A3 rakkis crossing
            ActorSnoEnum._a3dun_rmpt_frozendoor_a, // A3 stonefort
            ActorSnoEnum._catapult_a3dunkeep_warmachines_snow_firing, // A3 battlefields
            ActorSnoEnum._x1_crusader_trebuchet_pending_tar,
            ActorSnoEnum._event_1000monster_portal,
            ActorSnoEnum._a2dun_zolt_sandbridgebase_bossfight,
            ActorSnoEnum._px_highlands_camp_resurgentcult_portal,
            ActorSnoEnum._x1_bog_catacombsportal_beaconloc,
            ActorSnoEnum._x1_malthael_boss_orb_collapse, // malthael fight
            ActorSnoEnum._caout_oasis_mine_entrance_a, // check this one, maybe a bounty
            ActorSnoEnum._trout_leor_painting, // leoric manor
            ActorSnoEnum._a4dun_sigil_room_platform_a, // Holy Sanctum
            ActorSnoEnum._a3dun_rmpt_catapult_follower_event_gate, // a3 catapult event
            ActorSnoEnum._a1dun_leor_jail_door_superlocked_a_fake,
            ActorSnoEnum._cos_pet_mimic_01,
            ActorSnoEnum._shoulderpads_norm_base_flippy, // ???
            ActorSnoEnum._x1_abattoir_barricade_solid,
            ActorSnoEnum._x1_fortress_floatrubble_a,
            ActorSnoEnum._a3dun_keep_barrel_snow_no_skirt, // Sturdy Barrel
            ActorSnoEnum._x1_fortress_crystal_prison_shield,
            ActorSnoEnum._x1_westm_railing_a_01_piece1,
            ActorSnoEnum._x1_pand_hexmaze_corpse, // Corpse
            ActorSnoEnum._dh_companion_runec,
            ActorSnoEnum._loottype2_tristramvillager_male_c_corpse_01, // Dead Villager
            ActorSnoEnum._uber_bossworld3_st_demon_chainpylon_fire_azmodan, // uber realm
            ActorSnoEnum._trdun_crypt_skeleton_king_throne_parts, // uber realm
            ActorSnoEnum._double_crane_a_caout_miningevent_chest_minievent, // A2 howling plateau event
            ActorSnoEnum._p6_church_bloodchannel_a, // A2 Temple of Unborn 1
            ActorSnoEnum._a4dun_sigil_tile_invis_wall, // A4 Bounty "Watch Your Step"
            ActorSnoEnum._p1_tgoblin_gate, // Greed door
            ActorSnoEnum._p1_tgoblin_vault_door, // Vault door
            ActorSnoEnum._x1_urzael_soundspawner, // Urzael fight
            ActorSnoEnum._x1_urzael_soundspawner_02, // Urzael fight
            ActorSnoEnum._x1_urzael_soundspawner_03, // Urzael fight
            ActorSnoEnum._x1_urzael_soundspawner_04, // Urzael fight
            ActorSnoEnum._x1_westm_ex,
            ActorSnoEnum._trout_cath_entrance_door,
            ActorSnoEnum._x1_westm_shacklebar, // quest (Act V) The Templar's Reckoning
            ActorSnoEnum._x1_westm_shacklebar_b, // quest (Act V) The Templar's Reckoning
            ActorSnoEnum._x1_westm_stock, // quest (Act V) The Templar's Reckoning
        };
    }
}