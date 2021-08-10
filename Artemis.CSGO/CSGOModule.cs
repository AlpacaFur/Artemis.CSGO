using System;
using System.Collections.Generic;
using Artemis.Core;
using Artemis.Core.Modules;
using Artemis.Core.Services;
using Artemis.CSGO.DataModels;

namespace Artemis.CSGO
{
    [PluginFeature(Name = "CS:GO", Icon = "csgo-logo.svg")]
    public class CSGOModule : Module<CSGODataModel>
    {
        private readonly IWebServerService _webServerService;

        public CSGOModule(IWebServerService webServerService)
        {
            _webServerService = webServerService;
        }

        public override List<IModuleActivationRequirement> ActivationRequirements { get; } = new();

        public override void Enable()
        {
            ActivationRequirements.Add(new ProcessActivationRequirement("csgo"));

            JsonPluginEndPoint<CSGODataModel> jsonPluginEndPoint = _webServerService.AddJsonEndPoint<CSGODataModel>(this, "main", p =>
            {
                DataModel.map = p.map;
                DataModel.player = p.player;
                DataModel.provider = p.provider;
                DataModel.round = p.round;

                // Burning, flashed, and smoked are all out of 255, so convert them to a percent
                if (p.player.state != null)
                {
                    DataModel.player.state.burning = (p.player.state.burning / 255) * 100;
                    DataModel.player.state.flashed = (p.player.state.flashed / 255) * 100;
                    DataModel.player.state.smoked = (p.player.state.smoked / 255) * 100;
                }

                bool has_c4 = false;
                Player.Weapon current_weapon = null;

                foreach (KeyValuePair<string, Player.Weapon> entry in DataModel.player.weapons)
                {
                    // Temp variable to prevent unnecessary extra DataModel modifications
                    if (entry.Value.name == "weapon_c4") has_c4 = true;

                    // Parse weapon's string type as an Enum (defaults to "Other" if it doesn't match)
                    // This is to prevent future item types from breaking the plugin
                    Enum.TryParse(entry.Value.type, out Player.Weapon.WeaponType enumResult);
                    DataModel.player.weapons[entry.Key].weapontype = enumResult;

                    // If the weapon is active or reloading, it's the one the player is holding.
                    if (entry.Value.state == Player.Weapon.State.Active || entry.Value.state == Player.Weapon.State.Reloading)
                    {
                        current_weapon = entry.Value;
                    }
                }

                DataModel.player.has_c4 = has_c4;
                DataModel.player.current_weapon = current_weapon;
            });
        }

        private void WebServerServiceOnRequestException(object sender, EndpointExceptionEventArgs e)
        {
            throw e.Exception;
        }
        public override void Disable()
        {

        }

        public override void ModuleActivated(bool isOverride)
        {

        }

        public override void ModuleDeactivated(bool isOverride)
        {

        }

        public override void Update(double deltaTime)
        {

        }
    }
}