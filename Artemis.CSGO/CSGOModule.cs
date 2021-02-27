using Artemis.Core;
using Artemis.Core.Modules;
using Artemis.Core.Services;
using Artemis.CSGO.DataModels;
using SkiaSharp;



namespace Artemis.CSGO
{
    // The core of your module. Hover over the method names to see a description.
    public class CSGOModule : ProfileModule<CSGODataModel>
    {

        private readonly IWebServerService _webServerService;


        public CSGOModule(IWebServerService webServerService)
        {
            _webServerService = webServerService;
        }

        // This is the beginning of your plugin feature's life cycle. Use this instead of a constructor.
        public override void Enable()
        {
            DisplayName = "CS:GO";
            DisplayIcon = "Pistol";
            DefaultPriorityCategory = ModulePriorityCategory.Application;
            ActivationRequirements.Add(new ProcessActivationRequirement("csgo"));
            JsonPluginEndPoint<CSGODataModel> jsonPluginEndPoint = _webServerService.AddJsonEndPoint<CSGODataModel>(this, "main", p => {
                DataModel.map = p.map;
                DataModel.player = p.player;
                DataModel.provider = p.provider;
                DataModel.round = p.round;
            });
            jsonPluginEndPoint.ThrowOnFail = true;
            jsonPluginEndPoint.RequestException += WebServerServiceOnRequestException;
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