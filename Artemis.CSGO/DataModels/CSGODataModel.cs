using Artemis.Core.Modules;
using System.Collections.Generic;
using System.ComponentModel;

namespace Artemis.CSGO.DataModels
{

    public enum TeamEnum
    {
        None,
        T,
        CT,

    }
    public enum Activity
    {
        None,
        Menu,
        Playing,
        TextInput
    }

    public class CSGODataModel : DataModel
    {

        public Map map { get; set; } = new Map();
        public Player player { get; set; } = new Player();
        public Provider provider { get; set; } = new Provider();
        public Round round { get; set; } = new Round();

    }

    public class Map
    {
        public class Team
        {
            public int score { get; set; }
            [DataModelProperty(Name = "Consecutive Rounds Lost")]
            public int consecutive_round_losses { get; set; }
            [DataModelProperty(Name = "Timeouts Remaining")]
            public int timeouts_remaining { get; set; }
            [DataModelProperty(Name = "Matches Won This Series")]
            public int matches_won_this_series { get; set; }
        }

        public enum WinState
        {
            None,
            CT_Win_Elimination,
            CT_Win_Defuse,
            CT_Win_Time,
            T_Win_Elimination,
            T_Win_Bomb
        }
        public enum GamePhase
        {
            None,
            WarmUp,
            Live,
            FreezeTime,
            Bomb,
            Defuse,
            Over,
            Intermission
        }
        public string mode { get; set; }
        public string name { get; set; }

        public string phase { get; set; }
        public int round { get; set; }
        [DataModelProperty(Name = "CT")]
        public Team team_ct { get; set; } = new Team();
        [DataModelProperty(Name = "T")]
        public Team team_t { get; set; } = new Team();
        [DataModelProperty(Name = "Num Matches to Win Series")]
        public int num_matches_to_win_series { get; set; }
        [DataModelProperty(Name = "Current Spectators")]
        public int current_spectators { get; set; }
        [DataModelProperty(Name = "Souvenirs Total")]
        public int souvenirs_total { get; set; }
        public Dictionary<int, WinState> round_wins { get; set; } = new Dictionary<int, WinState>();

    }

    public class Player
    {
        public class Stats
        {
            public int kills { get; set; }
            public int assists { get; set; }
            public int deaths { get; set; }
            [DataModelProperty(Name = "MVPs")]
            public int mvps { get; set; }
            public int score { get; set; }
        }
        public class State
        {
            public int health { get; set; }
            public int armor { get; set; }
            [DataModelProperty(Name = "Has Helmet")]
            public bool helmet { get; set; }
            [DataModelProperty(Name = "Percent Flashed", Affix = "%")]
            public double flashed { get; set; }
            [DataModelProperty(Name = "Percent Smoked", Affix = "%")]
            public double smoked { get; set; }
            [DataModelProperty(Name = "Percent Burning", Affix = "%")]
            public double burning { get; set; }
            [DataModelProperty(Name = "Money", Prefix = "$")]
            public int money { get; set; }
            [DataModelProperty(Name = "Equipment Value", Prefix = "$")]
            public int equip_value { get; set; }
            [DataModelProperty(Name = "Round Kills")]
            public int round_kills { get; set; }
            [DataModelProperty(Name = "Round Headshot Kills")]
            public int round_killhs { get; set; }
        }

        public class Weapon
        {
            public enum State
            {
                None,
                Holstered,
                Active,
                Reloading,
            }
            public enum WeaponType
            {
                Other,
                Knife,
                Pistol,
                [Description("Submachine Gun")]
                SubmachineGun,
                [Description("Machine Gun")]
                MachineGun,
                Shotgun,
                Rifle,
                [Description("Sniper Rifle")]
                SniperRifle,
                Grenade,
                [Description("C4")]
                C4,
                [Description("Stackable Item")]
                StackableItem,
                BumpMine,
                BreachCharge,
                Tablet
            }
            public string name { get; set; }
            [DataModelProperty(Name = "Type")]
            public WeaponType weapontype { get; set; }
            [DataModelIgnore]
            public string type { get; set; }
            public string paintkit { get; set; }
            [DataModelProperty(Name = "Current Ammo")]
            public int ammo_clip { get; set; }
            [DataModelProperty(Name = "Clip Size")]
            public int ammo_clip_max { get; set; }
            [DataModelProperty(Name = "Ammo Reserve")]
            public int ammo_reserve { get; set; }
            public State state { get; set; }
        }

        [DataModelProperty(Name = "steamid")]
        public string steamid { get; set; }
        public string name { get; set; }
        [DataModelProperty(Name = "Team")]
        public TeamEnum team { get; set; }
        public Activity activity { get; set; }
        [DataModelProperty(Name = "Has Bomb")]
        public bool has_c4 { get; set; }
        [DataModelProperty(Name = "Observer Slot")]
        public int observer_slot { get; set; }

        public Dictionary<string, Weapon> weapons { get; set; } = new Dictionary<string, Weapon>();
        [DataModelProperty(Name = "Current Weapon")]
        public Weapon current_weapon { get; set; }
        [DataModelProperty(Name = "Match Stats")]
        public Stats match_stats { get; set; } = new Stats();
        [DataModelProperty(Name = "Player State")]
        public State state { get; set; } = new State();
        
    }

    public class Provider
    {
        public string name { get; set; }
        [DataModelProperty(Name = "App ID")]
        public int appid { get; set; }
        public int version { get; set; }
        [DataModelProperty(Name = "Steam ID")]
        public string steamid { get; set; }
        public int timestamp { get; set; }
    }
    public class Round
    {
        public enum BombState
        {
            None,
            Planted,
            Exploded,
            Defused
        }
        public enum PhaseState
        {
            None,
            WarmUp,
            FreezeTime,
            Live,
            Over
        }
        public PhaseState phase { get; set; }
        [DataModelProperty(Name = "Winning Team")]
        public TeamEnum win_team { get; set; }
        public BombState bomb { get; set; }
    }
}