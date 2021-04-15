using Artemis.Core;
using Artemis.Core.Modules;
using Artemis.Core.Services;
using Artemis.CSGO.DataModels;
using SkiaSharp;
using System;
using System.Collections.Generic;

namespace Artemis.CSGO
{
    public class CSGOModule : ProfileModule<CSGODataModel>
    {

        private readonly IWebServerService _webServerService;


        public CSGOModule(IWebServerService webServerService)
        {
            _webServerService = webServerService;
        }

        public override void Enable()
        {
            DisplayName = "CS:GO";
            DisplayIcon = "Pistol";
            DefaultPriorityCategory = ModulePriorityCategory.Application;
            ActivationRequirements.Add(new ProcessActivationRequirement("csgo"));

            JsonPluginEndPoint<CSGODataModel> jsonPluginEndPoint = _webServerService.AddJsonEndPoint<CSGODataModel>(this, "main", p =>
            {
                DataModel.map = p.map;
                DataModel.player = p.player;
                DataModel.provider = p.provider;
                DataModel.round = p.round;

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
                    // Check if weapon is the bomb, if so set the temp variable to true
                    if (entry.Value.name == "weapon_c4") has_c4 = true;

                    // Check if weapon is currently active or reloading (to get the weapon the player is holding).
                    if (entry.Value.state == Player.Weapon.State.Active || entry.Value.state == Player.Weapon.State.Reloading)
                    {
                        current_weapon = entry.Value;
                    }
                }

                DataModel.player.has_c4 = has_c4;
                DataModel.player.current_weapon = current_weapon;

            });
            //jsonPluginEndPoint.ThrowOnFail = true;
            //jsonPluginEndPoint.RequestException += WebServerServiceOnRequestException;
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

        public override void Render(double deltaTime, SKCanvas canvas, SKImageInfo canvasInfo)
        {

        }
    }
}