/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge;
using SkyForge.Services.ConsoleService;

namespace BonesOfDragonfall
{
    public class ChangeMagicPointPlayerConsoleCommand : IConsoleCommand
    {
        public string CommandName => "ChangeMagicPlayer";
        
        public void Process(DIContainer container, string[] parameters)
        {
            var updateValue = int.Parse(parameters[0]);
        
            var playerModel = container.Resolve<IGameStateProvider>().GetPlayerModel();
            
            playerModel.MagicPoint.Value += updateValue;
        }

        
    }
}