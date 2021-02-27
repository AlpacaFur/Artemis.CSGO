using Artemis.Core.DataModelExpansions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
        Menu,
        Playing,
        TextInput
    }

    public class CSGODataModel : DataModel
    {

        // You can even have classes in your datamodel, just don't forget to instantiate them ;)
        // [DataModelProperty(Name = "A class within the datamodel")]
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
            [DataModelProperty(Name = "Consecutive Round Losses")]
            public int consecutive_round_losses { get; set; }
            [DataModelProperty(Name = "Timeouts Remaining")]
            public int timeouts_remaining { get; set; }
            [DataModelProperty(Name = "Matches Won This Series")]
            public int matches_won_this_series { get; set; }
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
            public bool helmet { get; set; }
            private double percent_flashed { get; set; }
            [DataModelProperty(Name = "Percent Flashed")]
            public double flashed
            {
                get
                {
                    return percent_flashed;
                }
                set
                {
                    percent_flashed = Math.Floor(value / 255 * 100);
                }
            }
            private double percent_smoked { get; set; }
            [DataModelProperty(Name = "Percent Smoked")]
            public double smoked
            {
                get
                {
                    return percent_smoked;
                }
                set
                {
                    percent_smoked = Math.Floor(value / 255 * 100);
                }
            }
            private double percent_burning { get; set; }
            [DataModelProperty(Name = "Percent Burning")]
            public double burning
            {
                get
                {
                    return percent_burning;
                }
                set
                {
                    percent_burning = Math.Floor(value / 255 * 100);
                }
            }
            public int money { get; set; }
            [DataModelProperty(Name = "Round Kills")]
            public int round_kills { get; set; }
            [DataModelProperty(Name = "Round Headshot Kills")]
            public int round_killhs { get; set; }
            [DataModelProperty(Name = "Equipment Value")]
            public int equip_value { get; set; }
        }

        //public class Weapons
        //{
        //    [DataModelProperty(Name = "Weapon 0")]
        //    public Weapon weapon_0 { get; set; }
        //    [DataModelProperty(Name = "Weapon 1")]
        //    public Weapon weapon_1 { get; set; }
        //    [DataModelProperty(Name = "Weapon 2")]
        //    public Weapon weapon_2 { get; set; }
        //    [DataModelProperty(Name = "Weapon 3")]
        //    public Weapon weapon_3 { get; set; }
        //    [DataModelProperty(Name = "Weapon 4")]
        //    public Weapon weapon_4 { get; set; }
        //    [DataModelProperty(Name = "Weapon 5")]
        //    public Weapon weapon_5 { get; set; }
        //    [DataModelProperty(Name = "Weapon 6")]
        //    public Weapon weapon_6 { get; set; }
        //    [DataModelProperty(Name = "Weapon 7")]
        //    public Weapon weapon_7 { get; set; }
        //}

        public class Weapon
        {
            public enum State
            {
                none,
                holstered,
                active,
            }

            public string name { get; set; }
            public string paintkit { get; set; }
            public string type { get; set; }
            public int ammo_clip { get; set; }
            public int ammo_clip_max { get; set; }
            public int ammo_reserve { get; set; }
            public State state { get; set; }
        }
        [JsonProperty("weapons")]
        public Dictionary<object, Weapon> weapons { get; set; }

        [DataModelProperty(Name = "steamid")]
        public string steamid { get; set; }
        public string name { get; set; }
        [DataModelProperty(Name = "Observer Slot")]
        public int observer_slot { get; set; }
        [DataModelProperty(Name = "Team")]
        public TeamEnum team { get; set; }
        public Activity activity { get; set; }
        [DataModelProperty(Name = "Match Stats")]
        public Stats match_stats { get; set; } = new Stats();
        public State state { get; set; } = new State();

        //public bool has_c4
        //{
        //    get
        //    {
        //        foreach(KeyValuePair<string, Weapon> entry in weapons)
        //        {
        //            if (entry.Value.name == "weapon_c4") return true;
        //        }
        //        return false;
        //    }
        //}
    }

    public class Provider
    {
        public string name { get; set; }
        public int appid { get; set; }
        public int version { get; set; }
        public string steamid { get; set; }
        public int timestamp { get; set; }
    }
    public class Round
    {
        public string phase { get; set; }
    }
}