# CS:GO GSI

## Data Model

### Map

---

| Property - *type*                    | Description                                                  | Example Value                                                |
| ------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ |
| Mode - *string*                      | The current gamemode.                                        | "deathmatch", "competitive", "casual"                        |
| Name - *string*                      | The name of the current map. Most maps have a "de_" prefix.  | "de_dust2", "de_cache", "de_mirage"                          |
| Phase - *string*                     | The phase of the round. Note: this value is `Live` unless the user is an observer. | `None`, `Live`, `Intermssion`, `Warm Up`, `Freeze Time`, `Bomb`, `Defuse`, `Over` |
| Round - *int*                        | The current round number.                                    | 1, 5, 16                                                     |
| Num Matches to Win Series - *int*    | How many matches a team has to win to win the series (for tournaments only). | 0, 1, 2                                                      |
| Current Spectators - *int*           | The number of people currently spectating the game.          | 0, 5, 120                                                    |
| Souvenirs Total - *int*              | Unclear. Likely the number of souvenir cases dropped total in official tournaments. | 0, 5, 120                                                    |
| Round Wins - *Dictionary<int, enum>* | Each of the finished rounds and how they ended.              | {1: `CT Win Elimination`, 2: `CT Win Defuse`}, {1: `T Win Bomb`}, {1: `T Win Bomb`, 2: `T Win Elimination`} |

##### CT/T (Team)

| Property - *type*               | Description                                                  | Example Values |
| ------------------------------- | ------------------------------------------------------------ | -------------- |
| Score - *int*                   | CT/T's current score.                                        | 1, 9, 4        |
| Consecutive Rounds Lost - *int* | CT/T's rounds lost in a row.                                 | 0, 4, 2        |
| Timeouts Remaining - *int*      | CT/T's timeouts left.                                        | 0, 1, 2        |
| Matches Won This Series - *int* | CT/T's games won this series (only for tournaments, not regular matches) | 0, 1, 2        |

---

## Player

---

| Property - *type*                      | Description                                                  | Example Values                         |
| -------------------------------------- | ------------------------------------------------------------ | -------------------------------------- |
| steamid - *string*                     | The player's steamid                                         | 96562217852994284                      |
| Name - *string*                        | The player's name                                            | "Username", "RGBFan", "ArtemisEnjoyer" |
| Team - *enum*                          | Which team the player is on.                                 | `T`, `CT`                              |
| Activity - *enum*                      | What the player is doing. (Note: the activity is also `Menu` when the player presses escape while in game, not just when they're in the main menu). | `Menu`, `Playing`, `TextInput`         |
| Has Bomb - *bool*                      | Whether or not the player has the bomb.                      | True, False                            |
| Observer Slot - *int*                  | The slot of the player currently being spectated. (Observer only) | 0, 8, 4                                |
| Weapons - *Dictionary<string, Weapon>* | All they player's weapons in order.                          | **See Below**                          |
| Current Weapon - *Weapon*              | The weapon the player is currently holding.                  | **See Below**                          |
| Match Stats - *Stats*                  | The player's stats this match.                               | **See Below**                          |
| Player State - *State*                 | The player's current state.                                  | **See Below**                          |

**Weapon Class**

| Property - *type*    | Description                                         | Example Values                                               |
| -------------------- | --------------------------------------------------- | ------------------------------------------------------------ |
| Name - *string*      | The name of the weapon.                             | “weapon_knife_t”, “weapon_deagle”, “weapon_flashbang”        |
| Type - *enum*        | The type of the weapon.                             | `Other`,`Knife`,`Pistol`, `Submachine Gun`, `Machine Gun`, `Grenade`, `Shotgun`, `Rifle`, `Sniper Rifle`, `C4`, `Stackable Item`, `Bump Mine`, `Breach Charge`, `Tablet` |
| Paintkit - *string*  | The name of the weapon's skin.                      | "default", "cu_desert_eagle_corroden"                        |
| Current Ammo - *int* | How many bullets are in the player's weapon.        | 0, 250, 35                                                   |
| Clip Size - *int*    | How many bullets can fit in the weapon at once.     | 40, 8, 20                                                    |
| Ammo Reserve - *int* | How many bullets the player has outside the weapon. | 10, 45, 4                                                    |
| State - *enum*       | The current state of a the weapon.                  | `None`,`Holstered`, `Active`, `Reloading`                    |

**Stats**

| Property - *type* | Description                      | Example Values |
| ----------------- | -------------------------------- | -------------- |
| Kills - *int*     | The player's kills this match.   | 0, 5, 2        |
| Assists - *int*   | The player's assists this match. | 0, 5, 2        |
| Deaths - *int*    | The player's deaths this match.  | 0, 5, 2        |
| MVPs - *int*      | The player's MVPs this match.    | 0, 5, 2        |
| Score - *int*     | The player's score this match.   | 18, 202, 55    |

**State**

| Property - *type*            | Description                                                  | Example Values  |
| ---------------------------- | ------------------------------------------------------------ | --------------- |
| Health - *int*               | The player's health.                                         | 48, 100, 0      |
| Armor - *int*                | The player's armor.                                          | 48, 100, 0      |
| Has Helmet - *bool*          | Whether the player has a helmet equipped.                    | True, False     |
| Percent Flashed - *int*      | How flashed the player is as a percentage.                   | 48, 100, 0      |
| Percent Smoked - *int*       | How smoked the player is as a percentage.                    | 48, 100, 0      |
| Percent Burning - *int*      | How much the player is burning as a percentage. Note: The player only takes damage at 100% burning. | 48, 100, 0      |
| Money - *int*                | How much money the player has.                               | 16000, 1400, 0  |
| Equipment Value - *int*      | How valuable the player's held equipment is.                 | 5000, 1500, 400 |
| Round Kills - *int*          | How many kills the player has this round.                    | 1, 0, 5         |
| Round Headshot Kills - *int* | How many headshot kills the player has this round.           | 1, 0, 5         |

## Provider

| Property - *type*   | Description                                               | Example Values                            |
| ------------------- | --------------------------------------------------------- | ----------------------------------------- |
| Name - *string*     | The name of the app                                       | Always "Counter-Strike: Global Offensive" |
| App ID - *int*      | The Steam ID of the app                                   | Always "730"                              |
| Version - *int*     | The current version of CS:GO                              | 13793                                     |
| Steam ID - *string* | The user's Steam ID                                       | 12345678901234567                         |
| Timestamp - *int*   | The Unix timestamp at which the data was sent in seconds. | 1622837682                                |

## Round

| Property - *type* | Description                                                  | Example Values                                 |
| ----------------- | ------------------------------------------------------------ | ---------------------------------------------- |
| Phase - *enum*    | The current phase of the match.                              | `None`, `WarmUp`, `FreezeTime`, `Live`, `Over` |
| Win Team - *enum* | The winning team of the round.                               | `None`, `T`, `CT`                              |
| Bomb - *enum*     | The current state of the bomb. This field has been intentionally randomly delayed by Valve, so bomb timers will not be exact. | `None`, `Planted`, `Exploded`, `Defused`       |
